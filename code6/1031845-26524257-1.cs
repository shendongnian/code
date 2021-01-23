            //Convert to BigInteger
            ASCIIEncoding ByteConverter = new ASCIIEncoding();
            string publicKeyString = System.Text.Encoding.Default.GetString(publicKeyByte); 
            BigInteger publicKeyBI = BigInteger.Parse(publicKeyString);
            byte[] publicKeyByte2 = publicKeyBI.ToByteArray();
            string exponentString = System.Text.Encoding.Default.GetString(exponentByte); 
            BigInteger exponentBI = BigInteger.Parse(exponentString);
            byte[] exponentByte2 = exponentBI.ToByteArray();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSAParameters RSAKeyInfo = new RSAParameters();
            RSAKeyInfo = RSA.ExportParameters(false); //Export only public key
            //Set RSAKeyInfo to the public key values. 
            RSAKeyInfo.Modulus = publicKeyByte2.Reverse().ToArray();
            RSAKeyInfo.Exponent = exponentByte2.Reverse().ToArray();
            RSA.ImportParameters(RSAKeyInfo);
            byte[] encryptedPassword = RSA.Encrypt(passwordByte, false);
            return Convert.ToBase64String(encryptedPassword);
