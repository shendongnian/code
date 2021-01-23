        private static byte[] Encrypt(byte[] bytes)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(Properties.Settings.Default.PublicKeyXml);
                return rsa.Encrypt(bytes, true);
            }
        }
