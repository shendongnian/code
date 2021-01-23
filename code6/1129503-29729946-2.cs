    public interface IFoo
    {
        IFoo GetData();
    }
    public interface INewFoo : IFoo
    {
        new INewFoo GetData();
    }
    public class Foo : INewFoo
    {
        IFoo IFoo.GetData() { return GetData(); }
        public INewFoo GetData() { return new Foo(); }
    }
