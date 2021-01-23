    public class MyClass
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        private MyClass() {}
        public MyClass InstanceWithProp1(string prop1)
        {
            return new MyClass() {Prop1 = prop1};
        }
        public MyClass InstanceWithProp2(string prop2)
        {
            return new MyClass() {Prop2 = prop2};
        }
    }
