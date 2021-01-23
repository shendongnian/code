    using UnityEngine;
    using System.Collections;
    
    public class character : MonoBehaviour {
    	public float forwardSpeed = 20.0f;	public float rot = 0f;public float jumpSpeed = 100;public float gravity = 30f;
        public Material newMaterialRefcs1;
        public Material newMaterialRefcs2;
    	
        void Start () {
     
        }
        public float scrollSpeed = 0.25F;
         void Update () {
        if( Input.GetKey(KeyCode.RightArrow)){
    			scrollSpeed += 0.25f;
                transform.position += -transform.right * forwardSpeed * Time.deltaTime;
                renderer.material = newMaterialRefcs1;
                float offset = scrollSpeed;
            renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }if( Input.GetKey(KeyCode.LeftArrow)){
    			scrollSpeed += 0.25f;
                transform.position += transform.right * forwardSpeed * Time.deltaTime;
                renderer.material = newMaterialRefcs2;
                float offset = scrollSpeed;
            renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
     
        }
    		Vector3 isgrounded = transform.TransformDirection(Vector3.up);
    		if( Input.GetKeyDown(KeyCode.Space)&& Physics.Raycast(transform.position, isgrounded, 6)){
    			transform.position -= transform.up * jumpSpeed * Time.deltaTime*2;
    } 
    		 Physics.gravity = new Vector3(0, gravity, 0);
    		transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    }
    }
