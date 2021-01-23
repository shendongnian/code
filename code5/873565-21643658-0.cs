    public abstract class AbstractBase {
        public void Function2(){
            Debug.Log("2");
        }
    }
    public class Class1 : AbstractBase {
        public void BaseFunction(){
            Debug.Log("Base");
        }
    }
    public abstract class Class2 : Class1 {
        public void Function1(){
            Debug.Log("1");
        }
    }
