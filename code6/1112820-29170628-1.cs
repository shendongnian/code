    public interface IParameter<TFactory, T>
        where TFactory : new(), IFactory<T>
    { 
        T Value { get; set; }
    }
