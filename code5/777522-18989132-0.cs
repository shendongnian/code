    public Type FakeType { get; private set; }
    public T CreateInstance<T>() where T : SomeEntityBase
    {
         return (T) Activator.CreateInstance(FakeType);
    }
