    public static string GetTableName(this ObjectContext context, Type T)
    {
        var method = typeof(ObjectContext).GetMethod("CreateObjectSet", new Type[] { });
        var generic = method.MakeGenericMethod(T);
        var objectSet = generic.Invoke(context, null);
        var toTrace = typeof(ObjectSet<>).MakeGenericType(T).GetMethod("ToTraceString");
        var sqlString = (string)toTrace.Invoke(objectSet, null);
        //...
     }
