    public class A //main class
    {
        public B sth { get; set; }
        public C sthelse { get; set; }
        public A()
        {
            this.sth = new B(1000, "sth");
            this.sthelse = new C();
        }
        public IEnumerable<object> Nodes
        {
            get
            {
                yield return B;
                yield return C;
            }
        }
    }
    public class B
    {
        public D sth { get; set; }
        public B(ulong data, String abc)
        {
            this.sth = new D(data, abc);
        }
        public IEnumerable<object> Nodes
        {
            get
            {
                yield return D;
            }
        }
    }
    public class D
    {
        public ulong data { get; private set; }
        public String abc { get; private set; }
    
        public D(ulong data, String abc)
        {
            this.data = data;
            this.abc = abc;
        }
    
        public IEnumerable<object> Nodes
        {
            get
            {
                yield return data;
                yield return abc;
            }
        }
    }
