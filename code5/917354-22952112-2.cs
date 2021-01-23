    public class MyBehaviour : MonoBehaviour {
      void Start(){
        this.InvokeLater(1f, DoSomething1SecondLater);
      }
      public void DoSomething1SecondLater(){
        Debug.Log("Welcome to the future");
      }
    }
