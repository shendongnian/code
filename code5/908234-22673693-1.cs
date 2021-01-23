    public class CollisionHandler : MonoBehaviour {
        private IDictionary<Collider, string> colliders;
	    void Start () {
            int i = 0;
            colliders = new Dictionary<Collider, string>();
            foreach (var collider in GetComponents<Collider>())
                colliders.Add(collider, "collider_" + i++);
	    }
        void OnCollisionEnter(Collision collision)
        {
            Debug.Log(colliders[collision.contacts[0].thisCollider]);
	    }
    }
