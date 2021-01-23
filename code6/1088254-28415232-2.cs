    static void ExecuteCase<T1, T2>(T1 a, T2 
    {
        var method = GetMethod(typeof(Bar).GetMethods(BindingFlags.Public | BindingFlags.Static), typeof(T1), typeof(T2));
        if (method != null) { method.Invoke(null, new object[] {a, b}); }
           else { //* Handle method not found *// }
    }
