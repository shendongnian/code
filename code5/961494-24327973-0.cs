        static void Main(string[] args)
        {
            A a = new A();
            B b1 = new B();
            C C1 = new C() { Date = DateTime.Today, num = 2 };
            C C2 = new C() { Date = DateTime.Today.AddDays(1), num = 3 };
            b1.list.Add(C1);
            b1.list.Add(C2);
            a.list.Add(b1);
            B b2 = new B();
            C C3 = new C() { Date = DateTime.Today, num = 4 };
            C C4 = new C() { Date = DateTime.Today.AddDays(1), num = 5 };
            b2.list.Add(C3);
            b2.list.Add(C4);
            a.list.Add(b2);
            
            //we took advantage of the SelectMany extension method.
            var cResuls = a.list.SelectMany(x => x.list).Where(x=> x.Date==DateTime.Today).Sum(x=> x.num);
            Console.WriteLine("Sum of Today Value : {0} ", cResuls.ToString());
            Console.ReadLine();
        }
        public class A
        {
            public List<B> list { get; set; }
             public A()
            {
                list = new List<B>();
            }
        }
        public class B
        {
            public List<C> list { get; set; }
            public B()
            {
                list = new List<C>();
            }
        }
        public class C
        {
            public DateTime Date { get; set; }
            public int num { get; set; }
        } 
