    var valueHolder = new ValueHolder<T>
    {
          History = data
    };
    var c = Expression.Parameter(typeof(T), "c");
    var constantEx = Expression.Constant(valueHolder);
    var fieldEx = Expression.Field(constantEx, valueHolder.GetType().GetField("History"));
