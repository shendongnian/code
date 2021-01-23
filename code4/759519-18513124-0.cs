    public void SomeMethod<TBase, TChild>()
        where TBase : class, ISomeInterface<TChild>, new()
        where TChild : IAnotherInterface // No problem is here. 
    {
    }
    internal interface IAnotherInterface
    {
    }
    internal interface ISomeInterface<TChild>
    {
    }
