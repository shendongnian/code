    public static bool SetValue<T>(this List<T> collection, int oldValue, int newValue)
    {
        if ((Math.Min(newValue, oldValue) <= -1) ||
            (Math.Max(newValue, oldValue) > collection.Count()))
        {
            return false;
        }
        if (newValue != oldValue)
        {
            var value = collection[oldValue];
            collection.RemoveAt(oldValue);
            if (newValue == collection.Count())
            {
                collection.Add(value);
            }
            else
            {
                collection.Insert(newValue, value);
            }
        }
        return true;
    }
