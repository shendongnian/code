    public class ListOfFoo<T> : System.Collections.Generic.List<T>
    {
        private static readonly FromBytesFunc<T> BytesFromFunc = 
            (FromBytesFunc<T>)System.Delegate.CreateDelegate(
                typeof(FromBytesFunc<T>),
                typeof(T).GetMethod("FromBytes"));
        private delegate T2 FromBytesFunc<out T2>(byte[] bytes, ref int index);
        public static ListOfFoo<T> FromBytes(byte[] bytes, ref int index)
        {
            var count = bytes[index++];
            var listOfFoo = new ListOfFoo<T>();
            for (var i = 0; i < count; i++)
            {
                listOfFoo.Add(BytesFromFunc(bytes, ref index));
            }
            return listOfFoo;
        }
    }
