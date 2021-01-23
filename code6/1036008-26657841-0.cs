    public class ClassA
    {
        public string DoThisA { get; set; }
        public int DoThisB { get; set; }
        public bool DoThisC { get; set; }
        public void Init()
        {
            // You can call this from anywhere, even from an unrelated class
            MyClassInitializer<ClassA>.Init(this);
        }
    }
    public static class MyClassInitializer<T>
    {
        // Create the getters/setters you need, and make sure they're static.
        private static readonly Func<T, string> _getA = BuildGetter<string>("DoThisA");
        private static readonly Action<T, string> _setA = BuildSetter<string>("DoThisA");
        private static readonly Func<T, int> _getB = BuildGetter<int>("DoThisB");
        private static readonly Action<T, int> _setB = BuildSetter<int>("DoThisB");
        private static readonly Func<T, bool> _getC = BuildGetter<bool>("DoThisC");
        private static readonly Action<T, bool> _setC = BuildSetter<bool>("DoThisC");
        private static Func<T, TValue> BuildGetter<TValue>(string name)
        {
            var obj = Expression.Parameter(typeof(T));
            return Expression.Lambda<Func<T, TValue>>(Expression.Property(obj, name), obj).Compile();
        }
        private static Action<T, TValue> BuildSetter<TValue>(string name)
        {
            var obj = Expression.Parameter(typeof(T));
            var value = Expression.Parameter(typeof(TValue));
            return Expression.Lambda<Action<T, TValue>>(Expression.Assign(Expression.Property(obj, name), value), obj, value).Compile();
        }
        public static void Init(T obj)
        {
            // Here's your custom initialization method
            if (_getA(obj) == "Foo")
                _setB(obj, 42);
            else
                _setC(obj, true);
        }
    }
