        private static byte[] Decrypt(byte[] bytes)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(Properties.Settings.Default.PublicKeyXml);
                return rsa.PublicDecryption(bytes);
            }
        }
