    public void RequestData<TResult>()
    {
         var myName = typeof(TResult).Name;
         var type = typeof(TResult)
         if (type.IsGenericType)
         {
             myName = type.GetGenericArguments().First().Name;
         }
    }
