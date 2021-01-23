    public CodeBlockWorker<T> Ignore(
          Exception clazz, params Exception[] classes)
    {
         
        handlers.add(
           new KatchHandler<T>(
               //You can use FullName if you want to include the namespace
               clazz.GetType().Name, 
               classes.Select(t => t.GetType().Name)
               /* might need to call .ToArray() if your Constructor expects an array */);
     
        return this;
    }
