    class X
    {
        public virtual string A { get { return "foo"; } }
    }
    class Y : X
    {
        public override string A { get { return "bar"; } }
    }
