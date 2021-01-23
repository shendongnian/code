    using UnityEngine;
    using System.Collections;
    public class CameraController : MonoBehaviour {
    
        public GameObject cameraTarget; // object to look at or follow
        public GameObject player; // player object for moving
    
        public float smoothTime = 0.1f;    // time for dampen
        public bool cameraFollowX = true; // camera follows on horizontal
        public bool cameraFollowY = true; // camera follows on vertical
        public bool cameraFollowHeight = true; // camera follow CameraTarget object height
        public float cameraHeight = 2.5f; // height of camera adjustable
        Vector2 velocity; // speed of camera movement
    
        private Transform thisTransform; // camera Transform
        // Charleh - added these tweakable values - change as neccessary
        private float threshold = 0.5f; // Threshold distance before camera follows
        private float fraction = 0.7f;  // Fractional distance to move camera by each frame (smooths out the movement)
        // Use this for initialization
        void Start()
        {
            thisTransform = transform;
        }
    
        // Update is called once per frame
        void Update()
        {
            // Charleh - updated code here
            if (cameraFollowX)
            {
                if(Math.abs(cameraTarget.transform.position.x - thisTransform.position.x) > threshold)
                {
                    thisTransform.position.x = cameraTarget.transform.position.x - thisTransform.position.x * fraction;
                }
            }
            // Repeat for Y
        }
    }
