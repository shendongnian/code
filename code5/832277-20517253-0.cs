    public static String PhpMd5Raw(string str)
    {
        var md5 = System.Security.Cryptography.MD5.Create();
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(str); 
        var hashBytes = md5.ComputeHash(inputBytes);
        var latin1Encoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
        return latin1Encoding.GetString(hashBytes);
    }
