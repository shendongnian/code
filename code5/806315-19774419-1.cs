    public void GetString()
    {
        string STR = Decrypt(System.IO.File.ReadAllText("Path"));
        Console.WriteLine("The string is: {0}", STR);
    }
    // If you want to keep this running before the file exists, use this:
   
    /*
    public void GetString()
    {
        for(int i = 0; i > -1; ++i)
        {
            if(System.IO.File.Exists("Path"))
            {
                string STR = Decrypt(System.IO.File.ReadAllText("Path"));
                Console.WriteLine("The string is: {0}", STR);
                break;
            }
            else
            {
                //Do something if you want
            }
        }
    } */
    public String Decrypt(string ToDecrypt)
    {
        string Decrypted = null
        char[] Array = ToDecrypt.ToCharArray();
        for (int i = 0; i < Array.Length; i++)
        {
            Decrypted += Convert.ToString(Convert.ToChar(Convert.ToInt32(Array[i]) - 15));
        }
        return Decrypted;
    }
