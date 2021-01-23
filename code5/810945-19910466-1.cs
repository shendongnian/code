    // requires T to implement the interface and provide a parameterless ctor!
    public class ListOfFoo<T> : System.Collections.Generic.List<T>
        where T : IHaveFromBytesMethod<T>, new()
    {
        public static ListOfFoo<T> FromBytes(byte[] bytes, ref int index)
        {
            // create dummy instance for accessing static method via instance method
            T dummy = new T();
            var count = bytes[index++];
            var listOfFoo = new ListOfFoo<T>();
            for (var i = 0; i < count; i++)
            {
                // instead of calling the static method,
                // call the instance method on the dummy instance
                listOfFoo.Add(dummy.FromBytes(bytes, ref index));
            }
            return listOfFoo;
        }
    }
