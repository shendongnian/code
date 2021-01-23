        public string GenerateJWTToken(string rsaPrivateKey)
        {
            var rsaParams = GetRsaParameters(rsaPrivateKey);
            var encoder = GetRS256JWTEncoder(rsaParams);
            // create the payload according to your need
            var payload = new Dictionary<string, object>
            {
                { "iss", ""},
                { "sub", "" },
                // and other key-values 
            };
            var token = encoder.Encode(payload, new byte[0]);
            return token;
        }
        private static IJwtEncoder GetRS256JWTEncoder(RSAParameters rsaParams)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaParams);
            var algorithm = new RS256Algorithm(csp, csp);
            var serializer = new JsonNetSerializer();
            var urlEncoder = new JwtBase64UrlEncoder();
            var encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            return encoder;
        }
        private static RSAParameters GetRsaParameters(string rsaPrivateKey)
        {
            var byteArray = Encoding.ASCII.GetBytes(rsaPrivateKey);
            using (var ms = new MemoryStream(byteArray))
            {
                using (var sr = new StreamReader(ms))
                {
                    // use Bouncy Castle to convert the private key to RSA parameters
                    var pemReader = new PemReader(sr);
                    var keyPair = pemReader.ReadObject() as AsymmetricCipherKeyPair;
                    return DotNetUtilities.ToRSAParameters(keyPair.Private as RsaPrivateCrtKeyParameters);
                }
            }
        }
