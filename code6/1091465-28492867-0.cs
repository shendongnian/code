    public class CommonAB
    {
        public string PropertyA { get; private set; }
        public string PropertyB { get; private set; }
        public CommonAB(string a, string b)
        {
            PropertyA = a;
            PropertyB = b;
        }
    }
    public class ClassA : CommonAB
    {
        public ClassA(string a, string b)
            : base(a, b)
        {
        }
        public string PropertyX { get; set; }
        public void MethodA()
        {
            // do something
        }
    }
    public class ClassB : CommonAB
    {
        public ClassB(string a, string b)
            : base(a, b)
        {
        }
        public string PropertyY { get; set; }
        public void MethodB()
        {
            // do something else
        }
    }
    public class ClassC1 : ClassA
    {
        public ClassC1()
            : base("MyString", "MyOtherString")
        {
        }
    }
    public class ClassC2 : ClassA
    {
        public ClassC2()
            : base("MyString2", "MyOtherString2")
        {
        }
    }
    public class ClassD1 : ClassB
    {
        public ClassD1()
            : base("MyString", "MyOtherString")
        {
        }
    }
    public class ClassD2 : ClassB
    {
        public ClassD2()
            : base("MyString2", "MyOtherString2")
        {
        }
    }
