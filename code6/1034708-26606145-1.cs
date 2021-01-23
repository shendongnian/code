    public class ControlCloner<T>
    {
      public T CloneObject(T sourceObject)
     {
         T newObject = new T();
    
       // Set properties & events of newObject using reflection... look at the methods available on the Type class.
          return newObject;
       }
     }
