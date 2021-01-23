        //this class is to avoid having to supply generic type arguments 
        //to the static factory call (see CA1000)
        public static class Foo
        {
            public static Foo<TFoo> Create<TFoo>(TFoo value)
                where TFoo : class
            {
                return Foo<TFoo>.Create(value);
            }
            public static Foo<TFoo?> Create<TFoo>(TFoo? value)
                where TFoo : struct
            {
                return Foo<TFoo?>.Create(value);
            }
        }
        public class Foo<T>
        {
            private T item;
            private Foo(T value)
            {
                item = value;
            }
            public bool IsNull()
            {
                return item == null;
            }
            internal static Foo<TFoo> Create<TFoo>(TFoo value)
                where TFoo : class
            {
                return new Foo<TFoo>(value);
            }
            internal static Foo<TFoo?> Create<TFoo>(TFoo? value)
                where TFoo : struct
            {
                return new Foo<TFoo?>(value);
            }
        }
