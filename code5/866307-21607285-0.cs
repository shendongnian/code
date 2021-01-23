            string encryptedMessage = string.Empty;
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = m_ServerKey;
                m_IV = aes.IV;
                aes.Padding = PaddingMode.PKCS7;
                ServerIV = Convert.ToBase64String(m_IV);                
                // Encrypt the message 
                using (MemoryStream plaintext = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(plaintext, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                    {
                        byte[] messageBytes = Encoding.UTF8.GetBytes(i_Message);                    
                        cs.Write(messageBytes, 0, messageBytes.Length);
                        cs.Flush();
                        cs.Close();
                    }
                                     
                    encryptedMessage = Convert.ToBase64String(plaintext.ToArray());                    
                }
            }
            return encryptedMessage;
        }
