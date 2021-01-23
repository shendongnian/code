    private static Object syncObject = new Object()
    // this works not - see commented lin
    public static void DecryptFile(string FileName)
    {
        lock(syncObject)
        {
            string ToDecrypt = null;
            using (StreamReader sr = new StreamReader(FileName))
            {
                ToDecrypt = sr.ReadToEnd();
            }
            // here comes the exception
            using (StreamWriter sw = new StreamWriter(FileName, false))
            {
                string Decrypted = Decrypt(ToDecrypt, true);
                sw.Write(Decrypted);
            }
        }
    }
