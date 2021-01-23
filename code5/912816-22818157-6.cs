        private static byte[] Decrypt(byte[] bytes)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(Properties.Settings.Default.PrivateKeyXml);
                return rsa.Decrypt(bytes, true);
            }
        }
