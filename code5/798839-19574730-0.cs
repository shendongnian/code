    public class MyClass
    {
        public MyClass()
        { }
    }
    public class MyOtherClass : MyClass
    {
        private readonly string value;
        public MyOtherClass(string value)
        {
            this.value = value;
        }
        public string Export() { return this.value; }
    }
