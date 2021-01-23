    public class Projectile : MonoBehaviour
    {
        public Vector3 TargetPosition;
    	
    	void Update()
    	{
    		transform.position = Vector3.MoveTowards(transform.position, TargetPosition, speed * Time.DeltaTime);
    	}
    }
