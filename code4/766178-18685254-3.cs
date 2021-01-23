    public class Timed<T> where T : new() {
        DateTime init;
        T obj;
        public Timed() {
            init = new DateTime(0);
        }
        public T get() {
            if (DateTime.Now - init > max_lifetime) {
                obj = new T();
                init = DateTime.Now;
            }
            return obj;
        }
    }
