    public class MyScript : MonoBehaviour {
        public void GameObject creator;
        public void CreateClone() {
            GameObject clone = Instantiate(this);
            MyScript myScript = clone.GetComponent<MyScript>();
            myScript.creator = this;
        }
    }
        
