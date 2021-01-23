    public T Try(Action<T> action)
    {
       try 
       {
          return action();
       }
       catch(Exception ex)
       { 
           // Log the exception so you're at least aware of it
       }
    }
