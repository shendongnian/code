    public class TurretScript: MonoBehaviour
    { 
        //values that will be set in the Inspector
        public Transform Target;
        public float RotationSpeed;
        void Update()
        {
            var direction = Target.transform.position - transform.position;
            // Set Y the same to make the rotations turret-like:
            direction.y = transform.position.y; 
            var rot = Quaternion.LookRotation(direction, Vector3.up);      
            transform.rotation = Quaternion.RotateTowards(
                                             transform.rotation, 
                                             rot, 
                                             RotationSpeed * Time.deltaTime);
        }
    }
