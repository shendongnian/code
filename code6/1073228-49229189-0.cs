    public static Func<string, string> ToBase64PemFromKeyXMLString= (xmlPrivateKey) =>
            {
                if (string.IsNullOrEmpty(xmlPrivateKey))
                    throw new ArgumentNullException("RSA key must contains value!");
                var keyContent = new PemReader(new StringReader(xmlPrivateKey));
                if (keyContent == null)
                    throw new ArgumentNullException("private key is not valid!");
                var ciphrPrivateKey = (AsymmetricCipherKeyPair)keyContent.ReadObject();
                var asymmetricKey = new AsymmetricKeyEntry(ciphrPrivateKey.Private);
    
                PrivateKeyInfo privateKeyInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(asymmetricKey.Key);
                var serializedPrivateKey = privateKeyInfo.ToAsn1Object().GetDerEncoded();
                return Convert.ToBase64String(serializedPrivateKey);
            };
