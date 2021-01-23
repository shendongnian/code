    private string Decrypt(string s, string key)
            {
                try
                {
                    byte[] keyArray; byte[] toEncryptArray = Convert.FromBase64String(s);
                    System.Configuration.AppSettingsReader settingsReader = new System.Configuration.AppSettingsReader();
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key)); hashmd5.Clear();
                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                    tdes.Key = keyArray; tdes.Mode = CipherMode.ECB; tdes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    tdes.Clear(); return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch { return null; }
            }
