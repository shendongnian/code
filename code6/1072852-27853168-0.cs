        byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(userIDString);
        byte[] keyBytes = System.Convert.FromBase64String(keyInBase64);
        
        // initialize for EBC mode and PKCS5/PKCS7 padding
        PaddedBufferedBlockCipher cipher = new PaddedBufferedBlockCipher(new BlowfishEngine());
        KeyParameter param = new KeyParameter(keyBytes);
        cipher.Init(true, param);
        // encrypt and encode as base64
        byte[] encryptedBytes =  cipher.DoFinal(inputBytes);
        string idBase64 = System.Convert.ToBase64String(encryptedBytes);
