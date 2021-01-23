      public string Decryption(string i_Message)
        {
            string originalMessage = string.Empty;
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = m_ClientKey;
                aes.IV = Convert.FromBase64String(ServerIV);
                aes.Padding = PaddingMode.None;            
                string message = i_Message.Substring(1, i_Message.Length - 2);
                byte[] messageBytes = Convert.FromBase64String(message);
               
                // Decrypt the message 
                using (MemoryStream plaintext = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(messageBytes, 0, messageBytes.Length);
                        cs.Close();
                       
                        originalMessage = Encoding.UTF8.GetString(plaintext.ToArray());
                    }
                }
            }
            return originalMessage;
        }        
