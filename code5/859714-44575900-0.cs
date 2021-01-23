    [Serializable]
    public class CriptoEngine
    {
        #region Variables
        private string key;
        byte[] keyArray;
        byte[] arrayDecypt;
        byte[] resultArray;
        byte[] arrayEncrypt;
        #endregion
        #region Metodos Publicos
        public CriptoEngine(string user)
        {
            key = user;
        }
        public TDecrypData SetEncriptar<TEncr, TDecrypData>(TEncr objEncrypt)
        {
            object tEncr;
            arrayEncrypt = UTF8Encoding.UTF8.GetBytes(Convert.ToString(objEncrypt));
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray; tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            resultArray = cTransform.TransformFinalBlock(arrayEncrypt, 0, arrayEncrypt.Length);
            tdes.Clear();
            Type t = typeof(TDecrypData);
            switch (t.Name)
            {
                case "Byte[]":
                    tEncr = resultArray;
                    break;
                default:
                    tEncr = Convert.ToBase64String(resultArray, 0, resultArray.Length);
                    break;
            }            
            return (TDecrypData)tEncr;
        }
        public TEncryptData GetDescr<TDesc, TEncryptData>(TDesc objDecry)
        {
            arrayDecypt = Convert.FromBase64String(objDecry.ToString());
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            resultArray = cTransform.TransformFinalBlock(arrayDecypt, 0, arrayDecypt.Length);
            tdes.Clear();
            object crypto = UTF8Encoding.UTF8.GetString(resultArray);
            return (TEncryptData)crypto;
        }
        #endregion
    }
