    public class ApiRSA
        {
            private static string privateKey = // Generate a private key
    
            private static string publicKey = // Generate a public key
    
            public static string Decrypt(string data)
            {
                var rsa = new RSACryptoServiceProvider();
    
                byte[] dataByte = Convert.FromBase64String(data);
    
                rsa.FromXmlString(privateKey);
                var decryptedByte = rsa.Decrypt(dataByte, false);
    
                return Encoding.Unicode.GetString(decryptedByte);
            }
    
            public static string Encrypt(string data)
            {
                var rsa = new RSACryptoServiceProvider();
    
                var dataByte = Encoding.Unicode.GetBytes(data);
    
                rsa.FromXmlString(publicKey);
                var encryptedByte = rsa.Encrypt(dataByte, false);
    
                return Convert.ToBase64String(encryptedByte);
            }
    
            public static void GeneraterPrivatePublicKey(out string privateKey, out string publicKey)
            {
                var csp = new RSACryptoServiceProvider(1024);
    
                var privKey = csp.ExportParameters(true);
                var pubKey = csp.ExportParameters(false);
    
                {
                    var sw = new System.IO.StringWriter();
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    xs.Serialize(sw, privKey);
                    privateKey = sw.ToString();
                }
    
                {
                    var sw = new System.IO.StringWriter();
                    var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                    xs.Serialize(sw, pubKey);
                    publicKey = sw.ToString();
                }
            }
        }
