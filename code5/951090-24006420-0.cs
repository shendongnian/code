    public class MyDragMove : MonoBehaviour {
        public float speedDelta = 0.05f;
        public float decelerate = 1.0f;
        private bool startDrag;
        private Vector3 prePos;
        void Update () {
            this.rigidbody.drag = decelerate; //Rigidbody system can set drag also. You can use it and remove this line.
            if (Input.GetKeyDown (KeyCode.Mouse0)) {
                prePos = Input.mousePosition;
                startDrag = true;
            }
            if(Input.GetKeyUp(KeyCode.Mouse0))
                startDrag = false;
            if(startDrag)
                ForceCalculate();
        }
        void ForceCalculate()
        {
            Vector3 curPos = Input.mousePosition;
            Vector3 dir = curPos - prePos;
            float dist = dir.magnitude;
            float v = dist / Time.deltaTime;
            this.rigidbody.AddForce (dir * v * Time.deltaTime * speedDelta);
            prePos = curPos;
        }
    }
