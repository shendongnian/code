      internal static TType UnwrapProxy<TType>(TType proxy)
      {
         try
         {
            dynamic dynamicProxy = proxy;
            return dynamicProxy.__target;
         }
         catch (RuntimeBinderException)
         {
            return proxy;
         }
      }
