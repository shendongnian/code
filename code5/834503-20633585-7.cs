    private string GenerateAppSecretProof(string accessToken, string appSecret)
    {
        byte[] key = Base16.Decode(appSecret);
        byte[] hash;
        using (HMAC hmacAlg = new HMACSHA1(key))
        {
            hash = hmacAlg.ComputeHash(Encoding.ASCII.GetBytes(accessToken));
        }
        return Base16.Encode(hash);
    }
