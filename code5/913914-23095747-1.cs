        private void button4_Click(object sender, EventArgs e)
        {
            string fileName = System.IO.Path.Combine(Application.StartupPath, "alphaService.xml");
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            byte[] fileBytes = Encoding.ASCII.GetBytes(xmlDoc.ToString());
            byte[] EncryptedBytes = Encrypt(fileBytes);
            string EncryptedString = Encoding.ASCII.GetString(EncryptedBytes);
        }
        private static byte[] Encrypt(byte[] bytes)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(Properties.Settings.Default.PublicKeyXml);
                return rsa.Encrypt(bytes, false);
            }
        }
