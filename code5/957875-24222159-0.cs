    byte[] clearBytes = Encoding.ASCII.GetBytes(clearText);
    using (var encryptor = RijndaelManaged.Create())
    {
        encryptor.KeySize = 128;
        encryptor.Padding = PaddingMode.Zeros;
        encryptor.Mode = CipherMode.CFB;
        encryptor.Key = Encoding.ASCII.GetBytes("01234567891234560123456789123456");
        encryptor.IV = Encoding.ASCII.GetBytes("0123456789123456");
        using (MemoryStream ms = new MemoryStream())
        {
           using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
                cs.Close();
            }
            Array.Copy(ms.ToArray(), clearBytes, clearBytes.Length);
            clearText = Convert.ToBase64String(clearBytes);
         }
     }
     return clearText;
