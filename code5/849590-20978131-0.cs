    public interface IFoo
    {
        object Data { get; }
    }
    public interface IFoo<T> : IFoo
    {
        new T Data { get; }
    }
