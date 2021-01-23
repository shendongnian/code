    public class A
    {
    public virtual void doSomething() { Console.WriteLine("Class A"); }
    }
       
    class B : A
    {
    public override void doSomething()
    {
    base.doSomething();
    Console.WriteLine("Class Y");
    }
    }
          
    static void Main()
    {
    A b = new B();
    b.doSomething();
    Console.ReadKey();
    }
