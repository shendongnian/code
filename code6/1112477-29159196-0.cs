    interface IInc
    {
        int val { get; set; }
        IInc GetNew();
    }
    class A : IInc
    {
        public int val
        {
            get;
            set;
        }
        public virtual IInc GetNew()
        {
            return new A();
        }
        public IInc Inc()
        {
            var newObj = GetNew();
            newObj.val++;
            return newObj;
        }
    }
    class B : A
    {
        public override IInc GetNew()
        {
            return new B();
        }
    }
