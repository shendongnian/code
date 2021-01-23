    public CodeBlockWorker<T> Ignore<TClassZ, TClasses>(
          TClassZ clazz, params TClasses[] classes)
    where TClassZ : System.Exception
    where TClasses : System.Exception
    {
         
        handlers.add(
           new KatchHandler<T>(
               //You can use FullName if you want to include the namespace
               typeof(TClassZ).Name, 
               classes.Select(t => t.GetType().Name)
               /* might need to call .ToArray() if your Constructor expects an array */);
     
        return this;
    }
