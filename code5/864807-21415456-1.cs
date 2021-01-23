    public class Proxy<T>
    {
         public T GetProxy()
         {
             if (typeof(A).IsAssignableFrom(typeof(T)))
                 // Do something;
             else if (typeof(B).IsAssignableFrom(typeof(T)))
                // Do something else;                  
        }
    }
