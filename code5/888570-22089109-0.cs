    class Program
    {
        static void Main(string[] args)
        {
            Class2 instanceOfClass2 = new Class2();
        }
    }
    class Class1
    {
        public IList<string> MyList { get; set; }
        internal Class1()
        {
            MyList = new List<string>();
            MyList.Add("123");
        }
    }
    class Class2
    {
        public Class2()
        {
            Class1 c = new Class1();
            var a = c.MyList;
        }
    }
