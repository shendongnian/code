    public class B 
    {
        public int number;
    }
 
    public class A
    {
        public A()
        {
            MyB = new B();
        }
        public B MyB { get; private set; }
    }
