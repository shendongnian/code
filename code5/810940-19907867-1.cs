    sealed class RetType
    {
        public object Value
        {
            get;
            private set;
        }
        public int Index
        {
            get;
            private set;
        }
        public RetType(object value, int index)
        {
            Value = value;
            Index = index;
        }
    }
    public class ListOfFoo<T> : System.Collections.Generic.List<T>
    {
        static readonly Dictionary<Type, Func<byte[], int, RetType>> dic = new Dictionary<Type, Func<byte[], int, RetType>>
        {
            {
                typeof(Foo1),
                new Func<byte[], int, RetType>((bytes, index) =>
                {
                    var value = Foo1.FromBytes(bytes, ref index);
                    return new RetType(value, index);
                })
            }
            // add here others Foo
        };
        public static ListOfFoo<T> FromBytes(byte[] bytes, ref int index)
        {
            var count = bytes[index++];
            var listOf = new ListOfFoo<T>();
            for (var i = 0; i < count; i++)
            {
                var o = dic[typeof(T)](bytes, index);
                listOf.Add((T)o.Value);
                index = o.Index;
            }
            return listOf;
        }
    }
