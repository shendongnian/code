    private void Test<T>(T value)
    {
        if(typeof(T) == typeof(bool))
        {
            if((bool)(object)value)
                // do something
            else if (!(bool)(object)value)
                // do something else
        }
    }
