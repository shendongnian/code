    public class Helper<T> where T : new()
    {
        public static T Init(Action<T> body)
        {
            T obj = new T();
            body(obj);
            return obj;
        }
    }
