    public class QuizManager : MonoBehaviour {
    
        public Transform suggestionBtn;
    
        // Use this for initialization
        void Start () {
            Transform clone =  (Transform)Instantiate (suggestionBtn, 
                               new Vector3 (100, 400, 0), Quaternion.identity);
    
            // make instance the child of current object
            clone.parent = gameObject.transform; 
            // adjust the scale
            clone.transform.localScale = new Vector3(Xval, Yval, Zval);
        }
    }
    
