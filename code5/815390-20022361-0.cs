    public class A
    {
        public virtual void f() { Console.WriteLine( "A" ); }
    }
    public class B : A
    {
        public override void f() { Console.WriteLine( "B" ); }
    }
 
    public class C : A
    {
        public new void f() { Console.WriteLine( "C" ); }
    }
