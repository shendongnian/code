    using System.Security.Cryptography;
    private string HashPassword(string password,  string salt) 
    {
        string hashedString = CryptoConfig.CreateFromName("SHA256")
                                          .ComputeHash(salt+password);
        return hashedString;
    }
