    public class A : B
    {
        private void DoSomething()
        {
            C.Method1(); // should compile
        }
    }
    public abstract class B : C
    {
    }
    public class D
    {
        private void DoSomething()
        {
            C.Method1(); // shouldn't compile
        }
    }
    public class C
    {
        protected static void Method1()
        {
        }
    }
