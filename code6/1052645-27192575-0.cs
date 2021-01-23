    private static IEnumerable<object> CreateAListContainingOneObject(Type type)
    {
        var del = typeof(Program).GetMethod("CreateAGenericListContainingOneObject",
            BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(type);
        return del.Invoke(null, new object[] { }) as IEnumerable<object>;
    }
    private static List<T> CreateAGenericListContainingOneObject<T>()
        where T : new()
    {
	    return new List<T> { new T() };
    }
