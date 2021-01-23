    interface IBaseType { void InterfaceMethod(); }
    abstract class MyType : IBaseType
    {
        public void InterfaceMethod() { ...implementation here... }
        public abstract string DoSomething();
    }
