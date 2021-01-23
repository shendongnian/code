    public abstract class AbstractBase {
        public void BaseFunction(){
            Debug.Log("2");
        }
    }
    public class Class1 : AbstractBase {
        public void ClassOneFunction(){
            Debug.Log("Base");
        }
    }
    public abstract class Class2 : Class1 {
        public void ClassTwoFunction(){
            Debug.Log("1");
        }
    }
