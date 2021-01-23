    public class MyFactory : IClassFactory
    {
         public T GetObject<T>()
        {
            //TODO - get object of T type and return it
            return new T();
        }
    }
