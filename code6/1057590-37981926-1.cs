    private string ComputeHashSHA1(string input)
    {
        try
        {
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] hashedDataBytes = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(input));
            string digestValue = Convert.ToBase64String(hashedDataBytes);
            return digestValue;
    
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            return String.Empty;
        }
    
    }
