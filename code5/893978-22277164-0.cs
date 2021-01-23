    public class AI : MonoBehaviour
    {
        public Boid[] boids;
        void Update()
        {
            foreach (Boid boid in this.boids)
            {
                // Do something with boid
            }
        }
    }
    public class Boid : MonoBehaviour
    {
        public float searchRadius;
        // Anything else
    }
