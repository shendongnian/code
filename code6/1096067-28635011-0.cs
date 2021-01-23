        public static string FixedDecryptor(string content)
        {
            var cipher = new RijndaelManaged();
            var encrypted = Convert.FromBase64String(content);
            var key = new PasswordDeriveBytes(password, salt);
            using (var decryptor = cipher.CreateDecryptor(key.GetBytes(32), key.GetBytes(16)))
            using (var stream = new MemoryStream(encrypted))
            using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            {
                byte[] plain = new byte[encrypted.Length];
                int decrypted = crypto.Read(plain, 0, plain.Length);
                string data = Encoding.Unicode.GetString(plain, 0, decrypted);
                return data;
            }
        }
        public static string Decryptor(string content)
        {
            var cipher = new RijndaelManaged();
            var encrypted = Convert.FromBase64String(content);
            var key = new PasswordDeriveBytes("password", Encoding.ASCII.GetBytes("password"));
            using (var decryptor = cipher.CreateDecryptor(key.GetBytes(32), key.GetBytes(16)))
            using (var stream = new MemoryStream(encrypted))
            using (var crypto = new CryptoStream(stream, decryptor, CryptoStreamMode.Read))
            {
                byte[] plain = new byte[encrypted.Length];
                int decrypted = crypto.Read(plain, 0, plain.Length);
                string data = Encoding.Unicode.GetString(plain, 0, decrypted);
                return data;
            }
        }
