    private void Test<T>(T[] values)
    {
        foreach(T value in values)
        {
            if(typeof(T) == typeof(bool))
            {
                if (!(bool)(object)value)
                    // do something
            }
            else if (value == null)
                    // do something else
        }
    }
