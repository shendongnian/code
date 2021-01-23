    public class Proxy<T>
    {
         public T GetProxy()
         {
             if (typeof(T) == typeof(A))
                 // Do something;
             else if (typeof(T) == typeof(B))
                // Do something else;                  
        }
    }
