    public class MyDragMove : MonoBehaviour {
        public float speedDelta = 1.0f;
        public float maxSpeed = 5.0f;
        public Vector3 v;
        private Vector3 prePos;
        void Update () {
            if(Input.GetKey(KeyCode.Mouse0))
                prePos = Input.mousePosition;
            TowardTarget ();
        }
	
        void TowardTarget()
        {
            Vector3 targetPos = Camera.main.ScreenToWorldPoint (new Vector3(prePos.x, prePos.y, 10f)); //Assume your camera's z is -10 and cube's z is 0
            transform.position = Vector3.SmoothDamp (transform.position, targetPos, ref v, speedDelta, maxSpeed);
        }
    }
