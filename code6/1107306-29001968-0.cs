    class Program {
        Property<string> Foo = new Property<string>(() => "FOO!");
    }
    public class Property<T> where T : class {
        private Lazy<T> instance;
        public Property(Func<T> generator) {
            instance = new Lazy<T>(generator);
        }
        public T Value {
            get { return instance.Value; }
        }
        public static implicit operator T(Property<T> value) {
            return value.Value;
        }
        public static implicit operator Property<T>(T value) {
            return new Property<T>(() => value);
        }
    }
