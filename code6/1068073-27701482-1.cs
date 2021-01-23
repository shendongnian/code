    public class MyClass
    {
        //...
        public void SomeMethod()
        {
            _action();
            _action = null;
        }
        public void SomeOtherMethod()
        {
            if(action == null)
            {
                //...
            }
        }
    }
