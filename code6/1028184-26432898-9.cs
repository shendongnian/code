    private string Encrypt(string s, string key)
        {
            try
            {
                byte[] keyArray; byte[] encryptArray = UTF8Encoding.UTF8.GetBytes(s);
                System.Configuration.AppSettingsReader SettingReader = new System.Configuration.AppSettingsReader();
                MD5CryptoServiceProvider Hashmd5 = new MD5CryptoServiceProvider();
                keyArray = Hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key)); Hashmd5.Clear();
                TripleDESCryptoServiceProvider Tdes = new TripleDESCryptoServiceProvider();
                Tdes.Key = keyArray; Tdes.Mode = CipherMode.ECB; Tdes.Padding = PaddingMode.PKCS7;
                ICryptoTransform Ctransform = Tdes.CreateEncryptor();
                byte[] resultarray = Ctransform.TransformFinalBlock(encryptArray, 0, encryptArray.Length);
                Tdes.Clear(); return Convert.ToBase64String(resultarray, 0, resultarray.Length);
            }
            catch { return null; }
        }
