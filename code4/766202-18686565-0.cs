    public static T GetValueOrNull<T>(Object column)
    {
        // Convert   DBNull   values to   null   values for nullable value types, e.g.   int? , and strings.
        //   NB: The default value for non-nullable value types is usually some form of zero.
        //       The default value for   string   is    null .
        // Sadly, there does not appear to be a suitable constraint ("where" clause) that will allow compile-time validation of the specified type <T>.
        Debug.Assert(Nullable.GetUnderlyingType(typeof(T)) != null || typeof(T) == typeof(string), "Nullable or string types should be used.");
        if (!column.Equals(DBNull.Value)) // Don't trust   ==   when the compiler cannot tell if type <T> is a class.
            return (T)column;
        return default(T); // The default value for a type may be   null .  It depends on the type.
    }
