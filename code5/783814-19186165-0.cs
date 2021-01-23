    private static void GetFromDictionary<T>(IDictionary<String, Object> dictionary, String key, ref T outputLocation)
    {
        if (!dictionary.ContainsKey(key))
            return;
        var valueAsObject = dictionary[key];
        if (!CanBeCastTo<T>(valueAsObject))
            return;
        outputLocation = (T)Convert.ChangeType(valueAsObject, typeof(T));
    }
    private static bool CanBeCastTo<T>(Object thingToCast)
    {
        if (thingToCast is T)
            return true;
        var tType = typeof(T);
        if (tType == typeof(Int64) && thingToCast is Int32)
            return true;
        if (tType == typeof(Double) && thingToCast is Decimal)
            return true;
        return false;
    }
