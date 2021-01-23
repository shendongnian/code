    public int GetHashCode(T obj)
    {
        if (object.ReferenceEquals(obj, null))
        {
            return 0;
        }
        var value = PropertyInfo.GetValue(obj);
        return value == null ? 0 : value.GetHashCode();
    }
