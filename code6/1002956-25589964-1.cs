    public T MapFrom<T, V, TOut>(Expression<Func<T, TOut>> Source, Expression<Func<V, TOut>> Destination)
    {
        var sourceProperty = GetPropertyInfo<T, TOut>(Source);
        var destinationProperty = GetPropertyInfo<V, TOut>(Destination);
        // Use those
        // They're PropertyInfo classes, so it should be pretty easy to handle them however you would have expected to.
    }
