            private string ComputeHMACSHA1_PSHA(string input, string serversecret, string clientsecret)
        {
            try
            {
                byte[] signedInfoBytes = Encoding.UTF8.GetBytes(input);
                byte[] binarySecretBytesServer = Convert.FromBase64String(serversecret);
                byte[] binarySecretBytesClient = Convert.FromBase64String(clientsecret);
                byte[] key = KeyGenerator.ComputeCombinedKey(binarySecretBytesClient, binarySecretBytesServer, 256);
                
                HMACSHA1 hmac = new HMACSHA1(key);
                hmac.Initialize();
                byte[] hmacHash = hmac.ComputeHash(signedInfoBytes);
                string signatureValue = Convert.ToBase64String(hmacHash);
                return signatureValue;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
