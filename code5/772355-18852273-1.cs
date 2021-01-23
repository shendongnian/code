    public class A
    {
        public A()
        {
            throw new Exception();
        }
        
        public A(int i)
        {
            // this will not call the A(), but the base Object() constructor
        }
    }
    var a = new A(5); // no exception thrown
