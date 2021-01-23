    object GetValueFromClass(object Class)
    {
        System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
        Type t = asm.GetType("OneSubClass");
        System.Reflection.PropertyInfo pi = t.GetProperty("SubClassProperty");
        return pi.GetValue(Class, null);
    }
