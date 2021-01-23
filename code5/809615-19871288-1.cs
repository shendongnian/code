    public interface IProvider
    {
        Type Type { get; }
        object Create(IContext context);
    }
    public class MyIdentityProvider : IProvider
    {
        ...
    }
    kernel.Bind<IIdentifier>().ToProvider<MyIdentityProvider>();
