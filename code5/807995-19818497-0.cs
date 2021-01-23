        static void Main(string[] args)
        {
            MyClass1 c1 = new MyClass1();
            
            foreach (var s in c1.pp)
            {
                Console.WriteLine(s.GetType());    
            }
            Console.Read();
        }
        
    }
    public class MyClass1
    {
        public MyClass2 p;
        public List<object> pp;
        public MyClass1()
        {
            p = new MyClass2();
            pp = new List<object>();
            pp.Add(new MyClass2());
            pp.Add(new MyClass3());
            pp.Add(new MyClass4());
        }
    }
    public class MyClass2
    {
        public List<object> ppp;
        public MyClass2()
        {
            ppp = new List<object>();
            ppp.Add(new MyClass3());
            ppp.Add(new MyClass4());
        }
    }
    public class MyClass3
    {
        public int v;
    }
    public class MyClass4
    {
        public int v;
    }
