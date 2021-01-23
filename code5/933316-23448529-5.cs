    public static string CreatePasswordHash(string plainpassword)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(plainpassword);
        data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
        return System.Text.Encoding.ASCII.GetString(data);
    }
