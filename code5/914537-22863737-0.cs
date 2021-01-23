    public static async Task<T> GetDataFromTable<T>(string paramName)
    {
        var k = Activator.CreateInstance(typeof(T));
        var mn = typeof(T).GetProperty(paramName);
        if (mn == null)
            return (T)k;
        var data = GetDataFromListTable<T>();
        var retval = data.Select(t => t.mn);
    }
