     public static void DecryptFile(string FileName)
     {
        //string ToDecrypt = null;
        //using (StreamReader sr = new StreamReader(FileName))
        //{
         //   ToDecrypt = sr.ReadToEnd();
        //}
        // here comes the exception
        using (StreamWriter sw = new StreamWriter(FileName, false))
        {
            string Decrypted = Decrypt(ToDecrypt, true);
            sw.Write(Decrypted);
        }
    
    }
