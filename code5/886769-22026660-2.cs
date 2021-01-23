    public class TwoThingsIPC<T> where T : class
    {
    }
    public class TestClass
    {
    }
    var test1 = new TwoThingsIPC<int>(); //this will not compile because it is a value type
    //these will compile because they are reference types 
    var test2 = new TwoThingsIPC<TestClass>(); 
    var test3 = new TwoThingsIPC<List<TestClass>>(); 
    internal delegate void DWork();
    var test4 = new TwoThingsIPC<DWork>(); 
