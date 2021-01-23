    public class BulletBehavior : MonoBehaviour
    {
      private const float DefaultSpeed = 1.0f;
      private float startTime;
      
      public Vector3 destination;
      public Vector3 origin;
      public float? speed;
      public void Start()
      {
        speed = speed ?? DefaultSpeed;
        startTime = Time.time;
      }
      public void Update()
      {
        float fracJourney = (Time.time - startTime) * speed.GetValueOrDefault();
        this.transform.position = Vector3.Lerp (origin, destination, fracJourney);
      }
    }
