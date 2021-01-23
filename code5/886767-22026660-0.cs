    public class TwoThingsIPC<T> where T : IPassClass
    { 
    }
    public class TestClass
    {}
    public class TestClass2 : IPassClass
    {}
    var test1 = new TwoThingsIPC<TestClass>(); //this will not compile
    var test2 = new TwoThingsIPC<TestClass2>(); //this will compile because it implements IPassClass 
