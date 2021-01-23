    public class MyClass { }
    public class SubclassOfMyClass : MyClass { }
    public abstract class AbstractClass
    {
        public MyClass MyProperty { get; set; }
    }
    public class Subclass : AbstractClass
    {
        public new SubclassOfMyClass MyProperty
        {
            get { return base.MyProperty as SubclassOfMyClass; }
            set { base.MyProperty = value; }
        }
    }
    public class Test
    {
        public static void Main()
        {
            AbstractClass sub = new Subclass();
            sub.MyProperty = new MyClass();
            Subclass sub2 = (Subclass)sub;//casting succeeds since sub is Subclass 
            if (sub2.MyProperty == null)
                Console.WriteLine("sub2.MyProperty is null!");
        }
    }
