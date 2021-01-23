    public class createButton : MonoBehaviour {
        public MyButtonScript myNguiButtonPrefab;
        private int nextId;
        public createButton(){
            MyButtonScript newButton = (MyButtonScript )Instantiate(myNguiButtonPrefab);
            newButton.name = "newButton" + (nextId++);
            newButton.Setup(/* some parameters */);
        }
    }
