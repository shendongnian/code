    public static class Extensions
    {
        #region Fields
        public static Type bcType;
        #endregion
        #region Constructor
        static Extensions()
        {
            bcType = typeof(BitConverter);
        }
        #endregion
        public static byte[] GetObjectBytes(object obj)
        {
            Type typeObj = obj.GetType();
            MethodInfo miGetBytes = bcType.GetMethod("GetBytes", new Type[] { typeObj });
            if (miGetBytes == null)
                throw new InvalidOperationException("Method: GetBytes on BitConverter does not have an overload accepting one paramter of type: " + typeObj.FullName);
            byte[] bytesRet = (byte[])miGetBytes.Invoke(null, new object[] { obj });
            return bytesRet;
        }
        public static byte[] GetBytes(this String value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Boolean value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Byte value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this SByte value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Int16 value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Int32 value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Int64 value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this UInt16 value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this UInt32 value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this UInt64 value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Single value)
        {
            return GetObjectBytes(value);
        }
        public static byte[] GetBytes(this Double value)
        {
            return GetObjectBytes(value);
        }
        public static string ToBase64(this byte[] value)
        {
            return Convert.ToBase64String(value);
        }
    }
