    public int GenericMethod<T>(T t)
    {
        if (t is int)
        {
            return method1(t as int);
        }
        else if (t is bool)
        {
            return method2(t as bool);
        }
        else if (t is float)
        {
            return method3(t as float);
        }
        ...
        throw new ArgumentInvalidException(...);
    }
