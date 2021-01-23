    public class ListOfFoo<T> : System.Collections.Generic.List<T> where T : FooBase, new()
    {
        sealed class RetType<T>
        {
            public T Value
            {
                get;
                private set;
            }
            public int Index
            {
                get;
                private set;
            }
            public RetType(T value, int index)
            {
                Value = value;
                Index = index;
            }
        }
        static readonly Dictionary<Type, Func<byte[], int, RetType<T>>> dic = new Dictionary<Type, Func<byte[], int, RetType<T>>>
        {
            {
                typeof(Foo1),
                new Func<byte[], int, RetType<T>>((bytes, index) =>
                {
                    var value = Foo1.FromBytes(bytes, ref index);
                    return new RetType<T>(value, index);
                })
            }
            // here others Foo
        };
        public static ListOfFoo<T> FromBytes(byte[] bytes, ref int index)
        {
            var count = bytes[index++];
            var listOf = new ListOfFoo<T>();
            for (var i = 0; i < count; i++)
            {
                var o = dic[typeof(T)](bytes, index);
                
                listOf.Add(o.Value);
                
                index = o.Index;
            }
            return listOf;
        }
    }
