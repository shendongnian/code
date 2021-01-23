        private readonly ICryptoTransform encryptor;
        private readonly ICryptoTransform decryptor;
        private readonly UTF8Encoding encoder;
        var rm = new RijndaelManaged();
        encryptor = rm.CreateEncryptor(key, vector);
        decryptor = rm.CreateDecryptor(key, vector);
        encoder = new UTF8Encoding();
        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));         
        }
        public byte[] Encrypt(byte[] buffer)
        {
            var encryptStream = new MemoryStream();
            using (var cs = new CryptoStream(encryptStream, encryptor, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return encryptStream.ToArray();
        }
