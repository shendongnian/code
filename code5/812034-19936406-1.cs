    public abstract class MyTable {
        public abstract void SaveRows(...);
    }
    public class MyTable<T> : MyTable {
        public abstract void SaveRows(...) {
            // Write code here, with access to the generic type parameter
        }
    }
