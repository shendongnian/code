    private const string KEY = "Chiave";
    static void Main(string[] args)
    {
        string plainText = "Data to be encrypted";
        byte[] keyArray;
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(KEY));
        byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(plainText);
        TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
        tdes.Key = keyArray;
        tdes.Mode = CipherMode.CBC;
        tdes.Padding = PaddingMode.PKCS7;
        ICryptoTransform cTransform = tdes.CreateEncryptor();
        byte[] encArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
        // REMOVE THESE LINES 
        // tdes = new TripleDESCryptoServiceProvider();
        // tdes.Key = keyArray;
        // tdes.Mode = CipherMode.CBC;
        // tdes.Padding = PaddingMode.PKCS7;
        cTransform = tdes.CreateDecryptor();
        byte[] decArray = cTransform.TransformFinalBlock(encArray, 0, encArray.Length);
        // if (encArray.Length == decArray.Length)
        // {
        //    for (int i = 0; i < encArray.Length; ++i)
        //        Console.Out.Write("{0,3}|{1,3}", encArray[i], decArray[i]);
        //} else
        //    Console.Out.Write("Length error!");
        string result = UTF8Encoding.UTF8.GetString(decArray);
        Console.WriteLine(result);
        Console.In.Read();
    }
 
