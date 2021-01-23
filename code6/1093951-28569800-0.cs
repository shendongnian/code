    interface ITest3 : ITest1 { }
    public class Test3 : ITest3 { }
    
    A b = new B();
    b.TestProperty = new Test3();
