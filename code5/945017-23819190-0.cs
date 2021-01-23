    public class MyClass
    {
        private readonly MyClass1 prop1 = new MyClass1("Whatever");
        private readonly MyClass2 prop2 = new MyClass2("Whatever");
        private readonly MyClass3 prop3 = new MyClass3("Whatever");
        public MyProperty1 { get { return prop1; }
        public MyProperty2 { get { return prop2; }
        public MyProperty3 { get { return prop3; }
        // so on
    }
