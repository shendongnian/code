    public T Try(Action<T> action)
    {
       try 
       {
          return action();
       }
       catch(Exception)
       { }
    }
