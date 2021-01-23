    private static Dictionary<Type, object> SharedInstances;
    public static init()
    {
         if (!SharedInstances.ContainsKey(T.getType()))
         {
               SharedInstances.Add(T.getType(), default(T));
         }
    }
    public static T getSharedInstance()
    {
         return (T)SharedInstances[T.getType()];
    }
