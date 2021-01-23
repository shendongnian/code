    class MyClass
    {
        public interface IMySubClass
        {
            int One { get; }
            int Two { get; }
            int Three { get; }
        }
        private class MySubClass : IMySubClass
        {
            public int One { set; get; }
            public int Two { set; get; }
            public int Three { set; get; }
        };
        private MySubClass _objectMySubClass;
        public IMySubClass ObjectMySubClass
        {
            get { return _objectMySubClass; }
        }
        private void SetSomething()
        {
            _objectMySubClass.One = 5; //can do that
        }
    }
