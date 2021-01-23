    public class Foo
    {
        public void DoSomething() { /*nop*/ }
        private Action _doSomethingDelegate;
        public Action DoSomethingDelegate
        {
            get { return _doSomethingDelegate ?? (_doSomethingDelegate = DoSomething); }
        }
    }
