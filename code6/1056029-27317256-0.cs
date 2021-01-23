    public class A {}
    public class B : A { public object B}
    public class C : B { public object C; }
    var c = new C() { B = 1,  C = 2 };
    
