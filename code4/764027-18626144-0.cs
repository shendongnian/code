    if (type == typeof(string))
    {
        return new StringEntry(); //Obviously some special logic based on the type.
    }
    else
    {
        //Default logic
        return (IEntry) Activator.CreateInstance(typeof(Entry<>).MakeGenericType(type));
    }
