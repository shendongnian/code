    public class MyClass{
       public string _ClassGlobalVariable;
    
       public void MethodToWorkIn(){
           // this method knows about _ClassGlobalVariable and can work with it
           _ClassGlobalVariable = "a string";
       }
    }
