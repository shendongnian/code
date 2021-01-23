    public class ObjectCreator : MonoBehaviour
    {
        public GameObject prefab;
    
        void Awake()
        {
            Instantiate(prefab) as GameObject;
        }
    } 
