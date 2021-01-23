    public interface IParameter<TFactory, T>
        where TFactory : IFactory<T>
    { 
        T Value { get; set; }
    }
