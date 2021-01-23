    byte[] keySalt = new byte[] { 0x49, 0x76, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 };  
 
    Encrypt("original.txt",  "encrypted.txt", "myPassword", keySalt);  
    public static void Encrypt(string fileIn, string fileOut, string pass, byte[] keySalt)  
    {  
       PasswordDeriveBytes pdb = new PasswordDeriveBytes(pass, keySalt);  
     
       Rijndael alg = Rijndael.Create();  
       alg.Key = pdb.GetBytes(32);  
       alg.IV = pdb.GetBytes(16);  
     
       using (FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write))  
       {  
          using (FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read))  
          {  
             using (BinaryReader br = new BinaryReader(fsIn, Encoding.Default))  
             {  
                using (CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write))  
                {  
                  int len = (int)br.BaseStream.Length;  
                  cs.Write(br.ReadBytes(len), 0, len);  
                  cs.FlushFinalBlock();  
                }  
             }  
           }  
       }  
    }  
