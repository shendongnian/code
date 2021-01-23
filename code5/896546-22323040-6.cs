    [SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times")]
    public void MyMethodWithUsings()
    {
         using (MemoryStream msDecrypt = new MemoryStream(encryptedText.ToBase64Byte()))
         using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
         using (StreamReader srDecrypt = new StreamReader(csDecrypt))
         {
               return srDecrypt.ReadToEnd();
         }
    }
