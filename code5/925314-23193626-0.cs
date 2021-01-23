    public class ReadOnlyClass1
    {
        public int MyProperty { get; protected set; }
    }
    public class Class1 : ReadOnlyClass1
    {
        public new int MyProperty {
            get { return base.MyProperty; }
            set { base.MyProperty = value; }
        }
    }
