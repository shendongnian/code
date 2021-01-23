    private void Test<T>(params T[] values)
    {
        if(typeof(T) == typeof(bool))
        {
            foreach(bool b in values.Cast<bool>())
            {
                if (!b)
                    // do something
            }
        }
        else
        {
            foreach(T value in values)
            {
                if (value == null)
                // do something else
            }
        }
    }
