    public class Parent
    {
        public void Method()
        {
        }
    }
    public class Child : Parent
    {
        [Obsolete("This method should not be used", true)]
        public new void Method()
        {
        }
    }
