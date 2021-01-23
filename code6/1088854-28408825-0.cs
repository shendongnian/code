    public static class MachineKeyEncryptionExtensions
    {
        private static ThreadLocal<BinaryFormatter> formatterPool = 
              new ThreadLocal<BinaryFormatter>(() => new BinaryFormatter());
        public static string Encrypt(this object rci)
        {
            byte[] data;
            using (var ms = new MemoryStream())
            {
                formatterPool.Value.Serialize(ms, rci);
                data = ms.ToArray();
            }
            var ba=MachineKey.Protect(data, "encrypted data");
            return Convert.ToBase64String(ba);
        }
        public static T Decrypt<T>(this string encrypted)
        {
            var ba = Convert.FromBase64String(encrypted);
            var decodedArr=MachineKey.Unprotect(ba, "encrypted data");
            object o;
            using (var ms = new MemoryStream(decodedArr))
            {
                o = formatterPool.Value.Deserialize(ms);
            }
            return (T)o;
        }
        public static byte[] StringToByteArray(String hex)
        {
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }
        public static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }
    }
