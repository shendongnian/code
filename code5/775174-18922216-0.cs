    public abstract class A
    {
        protected abstract PropertyType PropertyValue {get;}
        public void Method()
        {
            Console.WriteLine(PropertyValue);
        }
    }
    public class B : A
    {
        protected override PropertyType Property { get { return PropertyType.B; } }
    }
    // etc...
