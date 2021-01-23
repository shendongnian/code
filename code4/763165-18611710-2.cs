    private static String SignThis(String StringToSign, string Key, string Account)
            {
                String signature = string.Empty;
                byte[] unicodeKey = Convert.FromBase64String(Key);
                using (HMACSHA256 hmacSha256 = new HMACSHA256(unicodeKey))
                {
                    Byte[] dataToHmac = System.Text.Encoding.UTF8.GetBytes(canonicalizedString);
                    signature = Convert.ToBase64String(hmacSha256.ComputeHash(dataToHmac));
                }
    
                String authorizationHeader = String.Format(
                      CultureInfo.InvariantCulture,
                      "{0} {1}:{2}",
                      "SharedKey",
                      Account,
                      signature);
    
                return authorizationHeader;
            }
