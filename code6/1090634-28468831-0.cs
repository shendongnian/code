    public static String GetString<T> (T value)
    {
    Type t = typeof(T);
    if (t.IsSubclassOf (typeof(Array)) || t.IsSubclassOf (typeof(IList)))
        return _ToString_List ((List)value);
    else if (t.IsSubclassOf (typeof(IDictionary)))
        return _ToString_Dictionary((Dictionary)value);
    else if (t.IsSubclassOf (typeof(IEnumerable)))
        return _ToString_Enumerable ((IEnumerable)value);
    else
        return value.ToString ();
    }
