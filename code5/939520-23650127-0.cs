    interface SomeBaseInterface
    {
        void SomeBaseMethod();
    }
    interface SomeInterface : SomeBaseInterface
    {
        void SomeMethod();
    }
    interface SomeOtherInterface : SomeBaseInterface
    {
        void SomeOtherMethod();
    }
    class ImplementingClass : SomeInterface, SomeOtherInterface
    {
        public void SomeMethod()
        {
        }
        public void SomeOtherMethod()
        {
        }
        public void SomeBaseMethod()
        {
        }
    }
