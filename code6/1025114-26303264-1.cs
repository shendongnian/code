    public abstract class BaseClass {
        public long Id { get; private set; }
        public BaseClass(long id) {
            this.Id = id;
        }
    }
    public abstract class BaseClass<T> : BaseClass where T : BaseClass<T>, new() {
        protected BaseClass(long id) : base(id) { }
        public static T Get(long id) {
            T item;
            return TryGet(id, out item) ? item : default(T);
        }
        public static bool TryGet(long id, out T item) {
            item = null; // Try to get item from cache here
            if (item != null) { return true; }
            else {
                T obj = new T();
                item = obj.TryGetFallback(id);
                return item != null;
            }
        }
        protected abstract T TryGetFallback(long id);
    }
    public abstract class DerivedClass<T> : BaseClass<T> where T : DerivedClass<T>, new() {
        public String Name { get; private set; }
        public DerivedClass() : base(0) {  }
        public DerivedClass(long id, String name)
            : base(id) {
            this.Name = name;
        }
        protected abstract override T TryGetFallback(long id);
    }
    public class DerivedDerivedClass : DerivedClass<DerivedDerivedClass> {
        public DerivedDerivedClass() {
            
        }
        protected override DerivedDerivedClass TryGetFallback(long id) {
            throw new NotImplementedException();
        }
    }
