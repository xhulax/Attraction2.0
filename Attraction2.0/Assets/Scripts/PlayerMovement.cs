using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    #region movement variables
    private Vector2 movementInput;
    private Vector2 smoothMovementInput;
    private Vector2 movementInputSmoothVelocity;
    [SerializeField] private float speed;
    #endregion

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, 
            movementInput,
            ref movementInputSmoothVelocity,
            0.1f);

        rb.velocity = smoothMovementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}


