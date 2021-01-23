    // if you not specify explictly the access modifier
    // it is internal for class/struct inside namespace
    // or private for inner types
    /*internal*/ class A
    {
    }
    public class B
    {
        public List<A> GetA() // <- this line give error Inconsistent accessibility...
        {
            return null;
        }
    }
