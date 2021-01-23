    public class MyImmutable
    {
        public MyImmutable(object x)
        {
            // do stuff with x
        }
        protected virtual MyImmutable GetNew(object x)
        {
            return new MyImmutable(x);
        }
        public MyImmutable Transform(object t)
        {
            // do stuff with t
            return GetNew(t);
        }
    }
    public class MySub : MyImmutable
    {
        public object Y { get; private set; }
        public MySub(object y, object x) : base(x)
        {
            Y = y;
        }
        protected override MyImmutable GetNew(object x)
        {
            return new MySub(x, Y);
        }
    }
