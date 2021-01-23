    public class Timed<T> {
        DateTime init;
        T obj;
        public Timed() {}
        public T get(void) {
            if (init == null || DateTime.Now - init > max_lifetime) {
                obj = new T();
                init = DateTime.Now;
            }
            return object;
        }
    }
