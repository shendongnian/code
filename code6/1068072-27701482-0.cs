    public class MyClass
    {
        private const Action AlreadyInvoked = null;
        private Action _action;
        public MyClass(Action action) {
            _action = action;
        }
        public void SomeMethod()
        {
            _action();
            _action = AlreadyInvoked;
        }
        public void SomeOtherMethod()
        {
            if(action == AlreadyInvoked)
            {
                //...
            }
        }
    }
