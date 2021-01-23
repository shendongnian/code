    public string GeneratePasswordHash(string thisPassword)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] tmpSource;
        byte[] tmpHash
    
        tmpSource = ASCIIEncoding.ASCII.GetBytes(thisPassword); // Turn password into byte array
        tmpHash = md5.ComputeHash(tmpSource);
        StringBuilder sOuput = new StringBuilder(tmpHash.Length);
        for (int i = 0; i < tmpHash.Lenth; i++)
        {
        sOutput.Append(tmpHash[i].ToString(“X2”));  // X2 formats to hexadecimal
        }
        return sOutput.ToString();
    }
