    public interface IFoo<out TOut> where TOut : class, new()
    {
    }
    public interface IFoo2<out TOut> : IDisposable where TOut : class, new()
    {
    }
