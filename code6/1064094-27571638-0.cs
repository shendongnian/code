    public static void Update<TSource, TKey>(
        this TSource source, 
        Action<TSource, TKey> action, 
        TKey newValue)
     where TSource : A
    {
         if (newValue != null)
         {
            action(source, newValue);
         }
    }
