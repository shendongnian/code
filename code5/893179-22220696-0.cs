    class Parent<T>
    {
        protected void Add(DataTable dt) { ... }        // the real business logics
        public virtual void AddRaw(T anything) {}
    }
    class Child1 : Parent<MyTable1>
    {
        public override void AddRaw(MyTable1 anything) { ... }
    }
    class Child2 : Parent<MyTable2>
    {
        public override void AddRaw(MyTable2 anything) { ... }
    }
