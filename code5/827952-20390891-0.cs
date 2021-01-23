        static void Main(string[] args)
        {
            Dictionary<string, BaseClass> zList = new Dictionary<string, BaseClass>();
            ClassA zA = new ClassA();
            zA.Value = "Test";
            zList["A"] = zA;
            ClassB zB = new ClassB();
            zB.Value = 555.666;
            zList["B"] = zB;
            Console.WriteLine(zList["A"].Value);
            Console.WriteLine(zList["B"].Value);
            Console.ReadLine();
        }
    }
    public class BaseClass
    {
        protected string _value;
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
    public class ClassA : BaseClass
    {
    }
    public class ClassB : BaseClass
    {
        private new double _value1;
        public new double Value
        {
            get { return _value1; }
            set { _value1 = value; _value = value.ToString(); }
        }
    }
