    public interface IPlugin
    {
        void DoSomething();
    }
    public class A : IPlugin
    {
        public virtual void DoSomething() {}
    }
    public class B : IPlugin
    {
        public virtual void DoSomething() {}
    }
    public class C : IPlugin
    {
        public virtual void DoSomething() {}
    }
    public class D : IPlugin
    {
        public virtual void DoSomething() {}
    }
