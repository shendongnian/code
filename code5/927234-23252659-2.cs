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
        public static byte[] GetBytes(this object value)
        {
            Type typeObj = value.GetType();
            MethodInfo miGetBytes = bcType.GetMethod("GetBytes", new Type[] { typeObj });
            if (miGetBytes == null)
                throw new InvalidOperationException("Method: GetBytes on BitConverter does not have an overload accepting one paramter of type: " + typeObj.FullName);
            byte[] bytesRet = (byte[])miGetBytes.Invoke(null, new object[] { obj });
            return bytesRet;
        }
    }
