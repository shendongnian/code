    public class Wrapper<T>
    {
       public T Value {get; set;}
    }
    
    public class A
    {
       public Wrapper<int> X {get; set;}
       public A()
       {
           X = new Wrapper<int>();
       }
    }
    
    public class B
    {
       public Wrapper<int> OtherX {get; set;}
    }
    
    var a = new A();
    var b = new B();
    b.OtherX = a.X;
    b.OtherX.Value = 1; //sets a.X to 1
    int otherX = b.OtherX.Value //gets value of a.X
