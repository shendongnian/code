    public class Test : MonoBehaviour {
    
        public Transform prefab;
    
    	// Use this for initialization
    	void Start () {
    	
    	}
    	
    	// Update is called once per frame
    	void Update () {
    
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("prefab id " + prefab.GetInstanceID() + " this id " + transform.GetInstanceID());
            }
    	}
    }
