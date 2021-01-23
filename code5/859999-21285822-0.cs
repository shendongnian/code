    public class Test
    {
        private Action _action;
        private void DoSomething()
        { 
            // Do something interesting
            _action = DoNothing;
        }
        private void DoNothing()
        {
        }
        public Test()
        {
            _action = DoSomething;
        }
        public void Call()
        {
            _action();
        }
    } // eo class Test
