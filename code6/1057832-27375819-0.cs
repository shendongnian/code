    public class TurretScript: MonoBehaviour
    { 
        //values that will be set in the Inspector
        public Transform Target;
        public float RotationSpeed;
        void Update()
        {
            var direction = (Target.position - transform.position).normalized;
            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                                              transform.rotation, 
                                              targetRotation, 
                                              Time.deltaTime * RotationSpeed);
        }
    }
