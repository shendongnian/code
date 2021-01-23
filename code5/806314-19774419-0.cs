    public void ReturnToOther()
    {
        string ToReturn = "MyString";
        System.IO.File.WriteAllText("Path", Encrypt(ToReturn));
    }
    
    public String Encrypt(string ToEncrypt)
    {
        string Encrypted = null
        char[] Array = ToEncrypt.ToCharArray();
        for (int i = 0; i < Array.Length; i++)
        {
            Encrypted += Convert.ToString(Convert.ToChar(Convert.ToInt32(Array[i]) + 15));
        }
        return Encrypted;
    }
