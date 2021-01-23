    public class ExampleClass : MonoBehaviour {
        public float sphereRadius;
        void Update() {
            if (Physics.CheckSphere(transform.position, sphereRadius))
                
               //Do something
        
            }
        }
