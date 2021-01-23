    public abstract class A
    {
    }
    
    public class B : A
    {
        public B(int i)
        {
    
        }
    }
    
    public static void Main()
    {
        // A a = new A(); // doesn't compile
        A a = new B(2); // valid
    }
