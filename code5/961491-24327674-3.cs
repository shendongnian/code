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
        
