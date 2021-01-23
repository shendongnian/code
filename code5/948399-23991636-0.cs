    interface IA
    {
        Initialize(List<something> list);
        DoSomething();
    }
    class C
    {
        private IA MyA;
        public C(IB b, IA a)
        {
            this.MyA = a;
            this.MyA.Initialize(b.GetList()); 
        }
        public DoSomethingInA()
        {
            this.MyA.DoSomething(); 
        }
    }
