    public class A
        {
            public A()
            {
                this.list = new List<B>();
            }
    
            public List<B> list { get; set; }
    
        }
    
        public class B
        {
            
            public B()
            {
                this.list = new List<C>();
            }
    
            public List<C> list { get; set; }
        }
    
        public class C
        {
            public DateTime Date { get; set; }
            public int num { get; set; }
        }
    
    
    
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
    
