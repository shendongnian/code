    private static void EncryptFile(string sInputFilename, string sOutputFilename, 
        string sKey)
    {
        using (var fsInput = new FileStream(sInputFilename, FileMode.Open, 
            FileAccess.Read))
        using (var fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, 
            FileAccess.Write))
        using (var desCryptoProvider = new DESCryptoServiceProvider())
        {
            desCryptoProvider.Key = Encoding.ASCII.GetBytes(sKey);
            desCryptoProvider.IV = Encoding.ASCII.GetBytes(sKey);
            using (var encryptor = desCryptoProvider.CreateEncryptor())
            using (var cryptoStream = new CryptoStream(fsEncrypted, encryptor, 
                CryptoStreamMode.Write))
            {
                try
                {
                    var bytearrayinput = File.ReadAllBytes(sInputFilename);
                    fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);
                    cryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length);
                }
                catch (Exception ex)
                {
                    var errors = new StringBuilder();
                    foreach (var pair in ex.Data)
                    {
                        errors.AppendLine(string.Format("{0} = {1}", pair.Key, pair.Value));
                    }
                    Console.WriteLine(errors.ToString());
                    LogWriter(errors.ToString(), true);
                }
            }
        }
    }
