    public class CustomList<T> : List<T> where T : new()
    {       
        public static async Task<CustomList<T>> CreateAsync(IQueryable<T> source)
        {           
            return new CustomList<T>(List<T> list); //do whatever you need in the contructor, constructor omitted
        }
        private T defaultInstance = new T();
        public T Default
        {
            get { return defaultInstance; }
        }
    }
