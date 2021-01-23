    public class Script2 : MonoBehaviour{
        public GameObject gameObjA; //reference to the game object the other script lives on. (this can also be done dynamically)
        void Start(){
            //logic to call target method on Script1
            var script1 = gameObjA.GetComponent<Script1>();
            script1.MethodToCall();
        }
        void Update() {}
    }
