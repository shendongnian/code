    public class DatabaseEntity<T> where T : Derp {
        protected abstract string Query { get; }
        public static IList<T> Load() {        
            return Database.Get(new DatabaseEntity<T>().Query);
        }
    }
