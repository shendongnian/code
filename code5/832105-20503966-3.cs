    public static List<Difference<T>> Detailed Difference<T>(this T val1, T val2)
        where T : new()
    {
        T newValue = new T();
        // later...
        v.MyCustomAttribute = // whatever it is
        if (v.MyCustomAttribute == MyCustomAttribute.FooA)
            f.SetValue(newValue, v.ValA);
        else if (v.MyCustomAttribute == MyCustomAttribute.FooB)
            f.SetValue(newValue, v.ValB);
        differences.Add(v);
        // other stuff...
    }
