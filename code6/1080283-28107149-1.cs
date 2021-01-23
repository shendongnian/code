    public static class ExtensionMethods
        {
            public static byte[] ToByteArray(this int i)
            {
                return BitConverter.GetBytes(i);
            }
            
            public static byte[] ToByteArray(this float a)
            {
                return BitConverter.GetBytes(a);
            }
        }
