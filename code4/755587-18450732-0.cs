    public string EncryptString( string inputString, int dwKeySize, string xmlString )
    {
            string name = inputString;
            FileStream fs = File.Create(@"license.lic");
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            StreamWriter write = new StreamWriter(fs);
            write.Write(name + "\r\n");
            string pkey = RSA.ToXmlString(false);
            write.Write(pkey + "\r\n");
            SHA1Managed Sha = new SHA1Managed();
            byte[] hashed = Sha.ComputeHash(Encoding.UTF8.GetBytes(name));
            byte[] signature = RSA.SignHash(hashed, CryptoConfig.MapNameToOID("SHA1"));
            write.Write(Convert.ToBase64String(signature));
            
            write.Close();
            fs.Close();
            return Convert.ToBase64String(hashed);    
		}
		public string DecryptString( string inputString, int dwKeySize, string xmlString )
		{
            FileStream fsSource = new FileStream(@"license.lic", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fsSource);
                        
            string name = reader.ReadLine();
            string pkey = reader.ReadLine();
            string signed = reader.ReadLine();
            byte[] bytes = Encoding.ASCII.GetBytes(name);
            SHA1Managed sHA1Managed = new SHA1Managed();
            byte[] rgbHash = sHA1Managed.ComputeHash(bytes);
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.FromXmlString(pkey);
            byte[] rgbSignature = Convert.FromBase64String(signed);
            bool flag = rSACryptoServiceProvider.VerifyHash(rgbHash, CryptoConfig.MapNameToOID("SHA1"), rgbSignature);
            return flag.ToString();
    }
