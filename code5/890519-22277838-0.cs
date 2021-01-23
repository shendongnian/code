    public class createButton : MonoBehaviour {
        public GameObject myNguiButtonPrefab;
        private int nextId;
        public createButton(){
            GameObject newButton = (GameObject)Instantiate(myNguiButtonPrefab);
            newButton.name = "newButton" + (nextId++);
            MyButtonScript buttonScript = newButton.GetComponent<MyButtonScript>();
            buttonScript.Setup(/* some parameters */);
        }
    }
