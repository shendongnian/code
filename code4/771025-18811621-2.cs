    private static string decryptedPW = "";
    public static string DecryptedPW
    {
        get
        {
            //need to initialize?
            if (decryptedPW.Length == 0)
            {
                string filePath = @"C:\ThickClient\tempPWDump.enc";
                decryptedPW = File.ReadAllText(filePath);
                File.Delete(filePath);
            }
            return decryptedPW;
        }
    }
