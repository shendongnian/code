    public class A
    {
        public A()
        {
            throw new Exception();
        }
        
        public A(int i)
        {
            // this will not call A()
        }
    }
    var a = new A(5); // no exception thrown
