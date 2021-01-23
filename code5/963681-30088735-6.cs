    public interface IImmutable : ICloneable { }
    public interface IImmutableBuilder { }
    public interface IImmutableOf<T> : IImmutable where T : class, IImmutable 
    {
        IImmutableBuilderFor<T> Mutate();
    }
    public interface IImmutableBuilderFor<T> : IImmutableBuilder where T : class, IImmutable
    {
        T Source { get; }
        IImmutableBuilderFor<T> Set<TFieldType>(string fieldName, TFieldType value);
        IImmutableBuilderFor<T> Set<TFieldType>(string fieldName, Func<T, TFieldType> valueProvider);
        IImmutableBuilderFor<T> Set<TFieldType>(Expression<Func<T, TFieldType>> fieldExpression, TFieldType value);
        IImmutableBuilderFor<T> Set<TFieldType>(Expression<Func<T, TFieldType>> fieldExpression, Func<TFieldType, TFieldType> valueProvider);
        T Build();
    }
