    public static T ParseOrDefault<T>(this T targetType, string source) where T : new() {
        var parameterTypes = new Type[] { source.GetType(), targetType.GetType().MakeByRefType() };
        var tryParseMethod = targetType.GetType().GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, null, parameterTypes, null);
        if (tryParseMethod != null) {
            var args = new object[] { source, null };
            var retval = (bool)tryParseMethod.Invoke(null, args);
            if (retval) return (T)args[1];
        }
        return new T();
    }
