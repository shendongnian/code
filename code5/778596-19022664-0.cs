    public class Encryption
        {
            private const string _defaultKey = "*3ld+43j";
     
     
            public static string Encrypt(string toEncrypt, string key)
            {
                var des = new DESCryptoServiceProvider();
                var ms = new MemoryStream();
     
                VerifyKey(ref key);
     
                des.Key = HashKey(key, des.KeySize / 8);
                des.IV = HashKey(key, des.KeySize / 8);
                byte[] inputBytes = Encoding.UTF8.GetBytes(toEncrypt);
     
                var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
     
                return HttpServerUtility.UrlTokenEncode(ms.ToArray());
            }
     
            public static string Decrypt(string toDecrypt, string key)
            {
                var des = new DESCryptoServiceProvider();
                var ms = new MemoryStream();
     
                VerifyKey(ref key);
     
                des.Key = HashKey(key, des.KeySize / 8);
                des.IV = HashKey(key, des.KeySize / 8);
                byte[] inputBytes = HttpServerUtility.UrlTokenDecode(toDecrypt);
     
                var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputBytes, 0, inputBytes.Length);
                cs.FlushFinalBlock();
     
                var encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
     
            }
     
            /// <summary>
            /// Make sure key is exactly 8 characters
            /// </summary>
            /// <param name="key"></param>
            private static void VerifyKey(ref string key)
            {
                if (string.IsNullOrEmpty(key)) 
                    key = _defaultKey;
     
                key = key.Length > 8 ? key.Substring(0, 8) : key;
     
                if (key.Length < 8)
                {
                    for (int i = key.Length; i < 8; i++)
                    {
                        key += _defaultKey[i];
                    }
                }
            }
     
            private static byte[] HashKey(string key, int length)
            {
                var sha = new SHA1CryptoServiceProvider();
                byte[] keyBytes = Encoding.UTF8.GetBytes(key);
                byte[] hash = sha.ComputeHash(keyBytes);
                byte[] truncateHash = new byte[length];
                Array.Copy(hash, 0, truncateHash, 0, length);
                return truncateHash;
            }
        
        }
