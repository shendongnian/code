    string dataToHash = "aaa";
    byte[] dataToHashBytes = System.Text.Encoding.ASCII.GetBytes(dataToHash);
    using (var md5 = MD5.Create())
    {
        var hashed = md5.ComputeHash(dataToHashBytes);
        Console.WriteLine(BitConverter.ToString(hashed).Replace("-", ""));
    }
