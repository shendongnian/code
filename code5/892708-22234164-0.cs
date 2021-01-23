    using UnityEngine;
    using System.Collections;
    // Added this to make sure that you'll not forget to add a rigidbody and a collider to your game object
    [RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
    public class BirdMovment : MonoBehaviour 
    {
        // I've changed it to Vector2, so it would be more comfortable to use with 2D physics
        public Vector2 flapVelocity;
        public float maxSpeed = 5f; 
        public float forwardSpeed = 1f;
        bool didFlap = false;
        Animator animator;
        // I'm assuming here that your game is 2D and used 2D physics.
        // If not - just switch to the regular Rigidbody, only a few modifications will be needed, if at all
        Rigidbody2D myRigidbody;
        // Here we will store the velocity achieved by flapping
        // It's calculating separately from the overall velocity and forwardSpeed for simplicity
        Vector2 userVelocity = Vector2.zero;
        // Use this for initialization
        void Start () {
            animator = GetComponent<Animator> ();
            myRigidbody = rigidbody2D;
        }
        void Update (){
            if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                didFlap = true; 
            }
        }
        // Physics update goes here
        void FixedUpdate () {
            // We do not need to apply gravity, as the rigidbody does it for us (and it's doing so in more realistic form that can simply be achieved)
            //Velocity += gravity * Time.deltaTime;
            // This is needed because you wan't to reset birds velocity on a flap, but at the same time want to retain realistic falling due to the gravity
            userVelocity.y = myRigidbody.velocity.y;
            if (didFlap) {
                animator.SetTrigger("DoFlap");
                didFlap = false;
                // Here we use user velocity instead of directly applying to rigidbody's velocity to simplify everything a little bit
                if (userVelocity.y < 0)
                    userVelocity.y = 0;
                userVelocity += flapVelocity;
                }
            userVelocity = Vector2.ClampMagnitude(userVelocity, maxSpeed);
            // If we will directly change our transform avoiding the physics engine, everything will brake, so we don't want to do that :)
            //transform.position += Velocity * Time.deltaTime;
            // Instead we are setting the velocity of our rigidbody, so the physics engine will make all work for us
            myRigidbody.velocity = userVelocity;
            // Adding a forwardSpeed to our velocity
            myRigidbody.velocity = new Vector2(forwardSpeed, myRigidbody.velocity.y);
            // This part is mostly intact, only we're now using our rigidbody's velocity for calculations
            float angle = 0;
            if(myRigidbody.velocity.y < 0)
            {
                angle = Mathf.Lerp(0, -45, -myRigidbody.velocity.y / maxSpeed);
            }
            transform.rotation = Quaternion.Euler(0,0,angle);
        }
    }
