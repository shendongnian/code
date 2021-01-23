    public class Class1
    {
        static void Main()
        {
            Class2 SecondClass = new Class2();
            SecondClass.StartSomething("hello world");
        }
    }
    public class Class2
    {
        public string Inherited;
        public void StartSomething(string value)
        {
            Inherited = value;
            InheritSomething();
        }
        public void InheritSomething()
        {
            Class3 thirdClass = new Class3(this);
            thirdClass.DoSomething();
        }
    }
    public class Class3 : Class2
    {
        private Class2 _class2;
        public Class3(Class2 class2)
        {
            _class2 = class2;
        }
        public void DoSomething()
        {
            Console.WriteLine(_class2.Inherited);
            Console.ReadLine();
        }
    }
