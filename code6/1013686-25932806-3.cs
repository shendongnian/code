    public class Script2 : MonoBehaviour{
        public GameObjectA go; //reference to the game object the other script lives on. (this can also be done dynamically)
        void Start(){
            //logic to call target method on Script1
            var targetScript = go.gameObject.GetComponent<Script1>();
            targetScript.MethodToCall();
        }
        void Update() {}
    }
