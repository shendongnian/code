    public class Property<T1> {
        T1 _t1;
        T1 Get<T1>() {
            return _t1;
        }
        void Set<T1>(T1 t1) {
            _t1 = t1;
        }
    }
    // C# doesn't have variadic generics, but you could do something like this
    // to get multiple type arguments
    public class Property<T1, T2> : Property<T1> {
        T2 _t2;
        T2 Get<T2>() {
            return _t2;
        }
        void Set<T2>(T2 t2) {
            _t2 = t2;
        }
    }
    public class Property<T1, T2, T3> : Property<T1, T2> {
        T3 _t3;
        T3 Get<T3>() {
            return _t3;
        }
        void Set<T3>(T3 t3) {
            _t3 = t3;
        }
    }
    public class Property<T1, T2, T3, T4> : Property<T1, T2, T3> {
    // ...
