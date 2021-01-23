    public IQueryable<T> GetData<T>() where T : class, IData
    {
        var factory = EntityFrameworkConfiguration.TypeFactory[typeof(T)];
        var context = factory.Item2();
        ThreadDataManager.GetCurrentNotNull().OnDispose += () =>
        {             
            context.Dispose();
        };
        var method = typeof(DbContext).GetMethod("Set", new Type[0]).MakeGenericMethod(factory.Item1);
        IQueryable<T> genericItem = (IQueryable < T >)method.Invoke(context, new object[0]);
        return genericItem;
    }
