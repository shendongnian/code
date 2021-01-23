        private static string Encrypt(byte[] input, DeriveBytes pwd)
        {
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                var rgbKey = pwd.GetBytes(KeySize / 8);
                using (var encryptor = symmetricKey.CreateEncryptor(rgbKey, InitVector))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(input, 0, input.Length);
                            cryptoStream.FlushFinalBlock();
                        }
                        var ctb = ms.ToArray();
                        return Convert.ToBase64String(ctb);
                    }
                }
            }
        }
        private static byte[] Decrypt(string input, DeriveBytes pwd)
        {
            var inputBytes = Convert.FromBase64String(input);
            using (var symmetricKey = new RijndaelManaged())
            {
                symmetricKey.Mode = CipherMode.CBC;
                symmetricKey.Padding = PaddingMode.PKCS7;
                var rgbKey = pwd.GetBytes(KeySize / 8);
                using (var decryptor = symmetricKey.CreateDecryptor(rgbKey, InitVector))
                {
                    using (var ms = new MemoryStream())
                    {
                        using (var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
                        }
                        return ms.ToArray();
                    }
                }
            }
        }
