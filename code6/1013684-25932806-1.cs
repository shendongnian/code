    public class Script2 : MonoBehaviour{
        public GameObjectA go; //reference to the game object the other script lives on. (this can also be done dynamically)
        void Start(){
            //place the logic below where you need to call the method from (in this case we place it in Start)
            var targetScript = go.gameObject.GetComponent<Script1>();
            targetScript.MethodToCall();
        }
        void Update() {}
    }
