      /// <summary>
        /// Encrypt using preferred provider. 
        /// </summary>
        /// <typeparam name="T">AesManaged,TripleDESCryptoServiceProvider,RijndaelManaged</typeparam>
        /// <param name="value">Value to be encrypted</param>
        /// <param name="decryptionKey">secret key .. see machine key descryptionKey</param>
        /// <param name="salt">salt for process</param>
        /// <returns></returns>
        public string Encrypt<T>(string value, string salt, string decryptionKey)
            where T : SymmetricAlgorithm, new() {
            var derivedKey = GenerateKey(decryptionKey, salt);
            SymmetricAlgorithm algorithm = new T();
            byte[] rgbKey = derivedKey.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIv = derivedKey.GetBytes(algorithm.BlockSize >> 3);
            ICryptoTransform transform = algorithm.CreateEncryptor(rgbKey, rgbIv);
            using (var buffer = new MemoryStream()) {
                using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Write)) {
                    using (var writer = new StreamWriter(stream, Encoding.Unicode)) {
                        writer.Write(value);
                    }
                }
                // before finished with the buffer return, now as the stream is now closed
                return Convert.ToBase64String(buffer.ToArray());
            }
        }
    public string Decrypt<T>(string text, string salt, string decryptionKey)
            where T : SymmetricAlgorithm, new() {
            // could catch errors here, and return a null string. ? 
            // "CryptographicException: Padding is invalid and cannot be removed"
            // can occur if there is a coding problem , such as invalid key or salt passed to this routine.
           
            var derivedKey = GenerateKey(decryptionKey, salt);
            SymmetricAlgorithm algorithm = new T();
            byte[] rgbKey = derivedKey.GetBytes(algorithm.KeySize >> 3);
            byte[] rgbIv = derivedKey.GetBytes(algorithm.BlockSize >> 3);
            ICryptoTransform transform = algorithm.CreateDecryptor(rgbKey, rgbIv);
            using (var buffer = new MemoryStream(Convert.FromBase64String(text))) {
                using (var stream = new CryptoStream(buffer, transform, CryptoStreamMode.Read)) {
                    using (var reader = new StreamReader(stream, Encoding.Unicode)) {
                        return reader.ReadToEnd(); // error here implies wrong keys supplied , and code or environment problem.. NASTY issue
                    }
                }
            }
        }
