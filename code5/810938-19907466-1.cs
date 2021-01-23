    public static class Utility
    {
        public static T FromBytes<T>(byte[] bytes, ref int index)
        {
              if (typeof(T) is Foo1)
              {
                   return Foo1.GetBytes(bytes, ref index);
              }
              //etc....
        }
    }
