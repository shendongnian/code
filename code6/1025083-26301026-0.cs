    public class CSharpClass
    {
        public static byte[] Foo()
        {
            // ...
            if (some error condition)
            {
                throw new SomeException(...); 
                // If you really want, write your own exception class
                // and have the error code be a property there.
            }
            byte[] result = new byte[1024];
            return result;
        }
    }
