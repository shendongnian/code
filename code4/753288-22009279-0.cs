    var enc = new RijndaelManaged();
    Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(pw, Encoding.ASCII.GetBytes(salt));
    enc.Key = key.GetBytes(encryption.KeySize / 8);
    enc.IV = key.GetBytes(encryption.BlockSize / 8);
    enc.Padding = PaddingMode.PKCS7;
