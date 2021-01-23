    public static class Crypto
    {
        public static string Encrypt(string text, string secret)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text");
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentNullException("secret");
            var salt = Encoding.UTF8.GetBytes(secret);
            using (var aes = new RijndaelManaged())
            {
                var key = new Rfc2898DeriveBytes(secret, salt);
                aes.Key = key.GetBytes(aes.KeySize / 8);
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var ms = new MemoryStream())
                {
                    ms.Write(BitConverter.GetBytes(aes.IV.Length), 0, sizeof(int));
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(text);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        public static string Decrypt(string cipher, string secret)
        {
            if (string.IsNullOrEmpty(cipher))
                throw new ArgumentNullException("cipher");
            if (string.IsNullOrEmpty(secret))
                throw new ArgumentNullException("secret");
            var salt = Encoding.UTF8.GetBytes(secret);
            using (var aes = new RijndaelManaged())
            {
                var key = new Rfc2898DeriveBytes(secret, salt);
                var bytes = Convert.FromBase64String(cipher);
                using (var ms = new MemoryStream(bytes))
                {
                    aes.Key = key.GetBytes(aes.KeySize / 8);
                    aes.IV = ReadByteArray(ms);
                    var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
        private static byte[] ReadByteArray(Stream s)
        {
            var rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }
            var buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }
            return buffer;
        }
    }
