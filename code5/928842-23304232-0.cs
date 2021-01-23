    public static Boolean IsChildOf<T>(this Object obj)
    {
       // Don't forget to handle obj == null.
       return obj.GetType().IsSubclassOf(typeof(T));
    }
