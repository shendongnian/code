    public virtual ObjectQuery<BaseObject> GetTypifiedBDOSet()
    {
        ObjectSet<BaseObject> objectSet = ((IObjectContextAdapter)DBContext).ObjectContext.CreateObjectSet<BaseObject>();
        MethodInfo methodInfo = objectSet.GetType().GetMethod("OfType", new Type[] { });
        ObjectQuery result = methodInfo.MakeGenericMethod(new Type[] { BDOType }).Invoke(objectSet, null) as ObjectQuery;
        return (ObjectQuery<BaseObject>)result.OfType<BaseObject>();
    }
