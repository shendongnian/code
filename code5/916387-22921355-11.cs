    byte[] key;
    string base64Key;
    using (var aes = Aes.Create())
    {
        // key as byte[]
        key = aes.Key;  
        // key as base64string - which one you use depends on how you store your keys
        base64Key= Convert.ToBase64String(aes.Key);
    }
