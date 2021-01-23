    .... in AddUser .....
    else
    {
        loginsDataSet.LoginsRow newUserRow = loginsDataSet.Logins.NewLoginsRow();
        string EncryptedPass = HashPass(password, email);
        ....
    } 
    ...
    public string HashPass(string password, string anEmailAddress)
    {
        SHA256 sha = new SHA256CryptoServiceProvider();
        //compute hash from the bytes of text
        sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password + anEmailAddress));  
        ....
    }
