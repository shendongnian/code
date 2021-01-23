    Class ScriptA : MonoBehaviour{
     
    //you are actually creating instance of this class to access variable.
     public static ScriptA instance;
     
     void Awake(){
     
         // give reference to created object.
         instance = this;
     }
     
     // by this way you can access non-static members also.
     public bool X = false;
    }
