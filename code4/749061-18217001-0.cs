    class Program
    {
        A a = A.CreateInstance();//works
        B b = B.CreateInstanceOfB();//works
        A ab = B.CreateInstanceOfA();//wont work
    }
    public class A
    {
        protected A()
        {
        }
        public static A CreateInstance()
        {
            return new A();
        }
    }
    public class B : A
    {
        protected B()
            : base()//
        {
        }
        public static B CreateInstanceOfB()
        {
            return new B();
        }
        public static A CreateInstanceOfA()
        {
            return new A();//This wont compile CS1540: Cannot access protected member...
        }
    }
