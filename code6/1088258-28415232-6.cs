    static void ExecuteCase(object a, object b)
    {
        var method = GetMethod(typeof(Bar).GetMethods(BindingFlags.Public | BindingFlags.Static), a.GetType(), b.GetType());
        if (method != null) { method.Invoke(null, new object[] {a, b}); }
        else { /* Handle method not found */ }
    }
