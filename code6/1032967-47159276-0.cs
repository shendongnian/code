    class Program
    {
        private static string _csr;
        private static string _publicKey;
        private static string _privateKey;
        static void Main(string[] args)
        {
            GeneratePkcs10("braspag.com.br", "braspag", "BR", RootLenght.RootLength2048);
            CryptDecryptTest();
            Console.ReadKey();
        }
        private static void GeneratePkcs10
            (string domainName, string companyName, string countryIso2Characters, RootLenght rootLength)
        {
            try
            {
                var rsaKeyPairGenerator = new RsaKeyPairGenerator();
                var secureRandom = new SecureRandom();
                // Note: the numbers {3, 5, 17, 257 or 65537} as Fermat primes.
                // NIST doesn't allow a public exponent smaller than 65537, since smaller exponents are a problem if they aren't properly padded.
                // Note: the default in openssl is '65537', i.e. 0x10001.
                var genParam = new RsaKeyGenerationParameters
                    (BigInteger.ValueOf(0x10001), secureRandom, (int)rootLength, 128);
                rsaKeyPairGenerator.Init(genParam);
                AsymmetricCipherKeyPair pair = rsaKeyPairGenerator.GenerateKeyPair();
                IDictionary attrs = new Hashtable();
                attrs.Add(X509Name.CN, domainName);
                attrs.Add(X509Name.O, companyName);
                attrs.Add(X509Name.C, countryIso2Characters);
                var subject = new X509Name(new ArrayList(attrs.Keys), attrs);
                var textWriter = new StringWriter(CultureInfo.InvariantCulture);
                var pemWriter = new PemWriter(textWriter);
                pemWriter.WriteObject(pair.Private);
                pemWriter.Writer.Flush();
                _privateKey = textWriter.ToString();
                textWriter.Close();
                textWriter = new StringWriter(CultureInfo.InvariantCulture);
                pemWriter = new PemWriter(textWriter);
                pemWriter.WriteObject(pair.Public);
                pemWriter.Writer.Flush();
                
                _publicKey = textWriter.ToString();
                textWriter.Close();
                ISignatureFactory signatureFactory = new Asn1SignatureFactory("SHA256WITHRSA", pair.Private, secureRandom);
                var pkcs10CertificationRequest = new Pkcs10CertificationRequest
                    (signatureFactory, subject, pair.Public, null, pair.Private);
                _csr = Convert.ToBase64String(pkcs10CertificationRequest.GetEncoded());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static void CryptDecryptTest()
        {
            const string originalText = "test";
            var encryptedText = RsaEncryptWithPublic(originalText, _publicKey);
            var decryptedText = RsaDecryptWithPrivate(encryptedText, _privateKey);
            Console.WriteLine(string.Format("Original Text: {0}", originalText));
            Console.WriteLine(string.Format("Encrypted Text: {0}", encryptedText));
            Console.WriteLine(string.Format("Decrypted Text: {0}", decryptedText));
        }
        public static string RsaEncryptWithPublic(string clearText, string publicKey)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(clearText);
            var encryptEngine = new Pkcs1Encoding(new RsaEngine());
            using (var txtreader = new StringReader(publicKey))
            {
                var keyParameter = (AsymmetricKeyParameter)new PemReader(txtreader).ReadObject();
                encryptEngine.Init(true, keyParameter);
            }
            var encrypted = Convert.ToBase64String(encryptEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length));
            return encrypted;
        }
        public static string RsaDecryptWithPrivate(string base64Input, string privateKey)
        {
            var bytesToDecrypt = Convert.FromBase64String(base64Input);
            AsymmetricCipherKeyPair keyPair;
            var decryptEngine = new Pkcs1Encoding(new RsaEngine());
            using (var txtreader = new StringReader(privateKey))
            {
                keyPair = (AsymmetricCipherKeyPair)new PemReader(txtreader).ReadObject();
                decryptEngine.Init(false, keyPair.Private);
            }
            var decrypted = Encoding.UTF8.GetString(decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length));
             return decrypted;
    }
        private enum RootLenght
        {
            RootLength2048 = 2048,
            RootLength3072 = 3072,
            RootLength4096 = 4096,
        }
    }
