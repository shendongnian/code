    public class Runner    
    {
        private string Run<T>(IEnumerable<T> items, IObjectSerializer<T> serializer) 
        {
            // ... Code
        
            var headers = serializer.SerializeHeaders(items);
        
            // ... Code
        
            foreach (var item in items)
            {
                var values = serializer.SerializeValues(item);
        
                // ... Code
            }
        
            // ... Code
        }
        
        public string Run<T>(IEnumerable<T> items)
        {
            return Run(items, new ObjectSerializer<T>());
        }
        
        public string Run<T>(IEnumerable<Wrapper<T>> items)
        {
            return Run(items, new ObjectWrapperSerializer<T>());
        }
    }        
    public interface IObjectSerializer<T>
    {
        string[] SerializeHeaders(IEnumerable<T> items);
        string SerializeValues(T item);
    }
        
    public class ObjectSerializer<T>: IObjectSerializer<T>
    {
        public string[] SerializeHeaders(IEnumerable<T> items) { ... }
        public string SerializeValues(T item) { ... }
    }
        
    public class ObjectWrapperSerializer<T> : IObjectSerializer<Wrapper<T>>
    {
        public string[] SerializeHeaders(IEnumerable<Wrapper<T>> items) { ... }
        public string SerializeValues(Wrapper<T> item) { ... }
    }
