using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    // Settings
    public float MoveSpeed = 30;
    public float SteerAngle = 20;
    public float Drag = 0.98f;

    // References
    public GameObject LeftTire;
    public GameObject RightTire;

    // Variables
    private Vector3 MoveForce;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        // Update force,
        // and move in the direction of the force
        MoveForce += transform.forward * MoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // Slowdown with drag
        MoveForce *= Drag;

        // Rotate tires
        float steerInput = Input.GetAxis("Horizontal");
        Quaternion tireRotation = Quaternion.Euler(Vector3.up * steerInput * 30);
        LeftTire.transform.localRotation = tireRotation;
        RightTire.transform.localRotation = tireRotation;

        // Steer car
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);
    }
}
