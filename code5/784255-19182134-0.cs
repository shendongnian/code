    interface IFoo
    {
        string GetFoo();
    }
    abstract class FooBase
    {
        public virtual string GetFoo()
        {
            return "Adam";
        }
    }
    class Foo : FooBase, IFoo
    {
    }
