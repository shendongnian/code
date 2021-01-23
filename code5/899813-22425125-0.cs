    public static byte[] EncryptTripleDES(byte[] dataToEncrypt, byte[] key, out byte[] iv){
        byte[] result;
        var tdes = new TripleDESCryptoServiceProvider { KeySize = 128, Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };
        tdes.Key = key;
        iv = tdes.IV;
        using(ICryptoTransform cTransform = tdes.CreateEncryptor()){
            result = cTransform.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            tdes.Clear();
        }
        return result;
    }
    public static byte[] DecryptTripleDES(byte[] dataToDecrypt, byte[] key, byte[] iv){
        byte[] result;
        var tdes = new TripleDESCryptoServiceProvider { KeySize = 128, Mode = CipherMode.CBC,IV = iv,Padding = PaddingMode.PKCS7 };
        tdes.Key = key;
        using (ICryptoTransform cTransform = tdes.CreateDecryptor()){
            result = cTransform.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            tdes.Clear();
        }
        return result;
    }
