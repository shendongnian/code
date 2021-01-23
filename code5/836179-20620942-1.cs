    public class Base
    {
        public void Method()
        {
            Console.WriteLine("Base.Method()");
        }
    }
    
    public class Derived : Base
    {
        public new void Method()
        {
            Console.WriteLine("Derived.Method()");
        }
    }
    
    Derived obj = new Derived();
    obj.Method(); // Will output "Derived.Method()"
    ((Base)obj).Method() // Will output "Base.Method()"
