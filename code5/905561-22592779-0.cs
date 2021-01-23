    using UnityEngine;
    using System.Collections;
    [RequireComponent(typeof (Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public class TouchControls : MonoBehaviour {
	public GUITexture guiLeft;
	public GUITexture guiRight;
	public GUITexture guiJump;
	public float moveSpeed = 5f;
	public float jumpForce = 50f;
	public float maxJumpVelocity = 2f;
	private bool moveLeft, moveRight, doJump = false;
	void Update () {
		if (Input.touchCount > 0) {
			for(int i = 0; i < Input.touchCount; i++) {
				Touch t = Input.GetTouch(i);
				if (t.phase == TouchPhase.Began) {
					if (guiLeft.HitTest(t.position, Camera.main)) {
						Debug.Log("Touching Left Control");
						moveLeft = true;
					}
					if (guiRight.HitTest(t.position, Camera.main)) {
						Debug.Log("Touching Right Control");
						moveRight = true;
					}
					
					// Are we touching the jump button?
					if (guiJump.HitTest(t.position, Camera.main)) {
						Debug.Log("Touching Jump Control");
						doJump = true;
					}
				}
				if (t.phase == TouchPhase.Ended) {
					// Stop all movement
					doJump = moveLeft = moveRight = false;
					rigidbody2D.velocity = Vector2.zero;
				}
			}
		}
		if (Input.GetMouseButtonDown(0)) {
			if (guiLeft.HitTest(Input.mousePosition, Camera.main)) {
				Debug.Log("Touching Left Control");
				moveLeft = true;
			}
			if (guiRight.HitTest(Input.mousePosition, Camera.main))	{
				Debug.Log("Touching Right Control");
				moveRight = true;
			}
			if (guiJump.HitTest(Input.mousePosition, Camera.main)) {
				Debug.Log("Touching Jump Control");
				doJump = true;
			}
		}
		
		if (Input.GetMouseButtonUp(0)) {
			doJump = moveLeft = moveRight = false;
			rigidbody2D.velocity = Vector2.zero;
		}
	}
	
	void FixedUpdate() {
		if (moveLeft) {
			rigidbody2D.velocity = -Vector2.right * moveSpeed;
		}
		
		if (moveRight) {
			rigidbody2D.velocity = Vector2.right * moveSpeed;
		}
		
		if (doJump) {
			if (rigidbody2D.velocity.y < maxJumpVelocity) {
				rigidbody2D.AddForce(Vector2.up * jumpForce);
			} else {
				doJump = false;
			}
		}
	}
    }
