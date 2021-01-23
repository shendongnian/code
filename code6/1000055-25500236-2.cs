    public bool Equals(T obj1, T obj2)
    {
        if (ReferenceEquals(obj1, obj2))
        {
            return true;
        }
        if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null))
        {
            return false;
        }
        return object.Equals(PropertyInfo.GetValue(obj1, null), 
                             PropertyInfo.GetValue(obj2, null));
    }
