    private static bool IsCollection(object obj)
    {
        bool isCollection = false;
        Type objType = obj.GetType();
        if (!typeof(string).IsAssignableFrom(objType) && typeof(IEnumerable).IsAssignableFrom(objType))
        {
            isCollection = true;
        }
        return isCollection;
    }
    private static bool IsDate(object obj)
    {
        bool isDate = false;
        if (typeof(DateTime) == obj.GetType() || typeof(DateTimeOffset) == obj.GetType())
        {
            isDate = true;
        }
        return isDate;
    }
