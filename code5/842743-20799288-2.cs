    public static void WriteFile(string FilePath, string Data)
    {
    FileStream fout = new FileStream(FilePath, FileMode.OpenOrCreate,
      FileAccess.Write);
    TripleDES tdes = new TripleDESCryptoServiceProvider();
    CryptoStream cs = new CryptoStream(fout, tdes.CreateEncryptor(key, iv),
       CryptoStreamMode.Write);
    byte[] d = Encoding.ASCII.GetBytes(Data);
    cs.Write(d, 0, d.Length);
    cs.WriteByte(0);
    cs.Close();
    fout.Close();
    }
