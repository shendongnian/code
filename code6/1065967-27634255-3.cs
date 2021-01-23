    static string DecryptFile(string sInputFilename, string sKey)
    {
        using (var DES = new DESCryptoServiceProvider())
        {
            DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            
            using (var fsread = new FileStream(sInputFilename, FileMode.Open,FileAccess.Read))
            using (var desdecrypt = DES.CreateDecryptor())
            using (var cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read))
            using (var reader = new StreamReader(cryptostreamDecr))
            {
                // this is a stream content as a string, you don't need to write and read it again
                return reader.ReadToEnd();
            }
        }
    }
