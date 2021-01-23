    abstract class AbstractClass<T>
    where T: AbstractClass<T> //restrict T as a child of AbstractClass<T>
    {
        bool update()
        {
            Connection.Update<T>(this as T);
        }
    }
    
    class Entity : AbstractClass<Entity>
    {
    }
    
    class Connection
    {
        public static void Update<T>(T obj)
        {
            someMethod<T>()
        }
    }
