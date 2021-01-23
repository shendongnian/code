    public class Tree : MonoBehaviour
    {
        void Update()
        {
            if(Vector3.Distance(transform.position, Camera.main.transform.position) > 500)
                Destroy(gameObject);
           
        }
    }
