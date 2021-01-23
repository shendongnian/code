    public static T Load<T>(string fileSpec)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        using (FileStream stream = File.OpenRead(fileSpec))
        {
            using (CryptoStream cryptoStream = 
                   new CryptoStream(stream, des.CreateDecryptor(key, iv),
                                    CryptoStreamMode.Read))
            {
                return (T)formatter.Deserialize(cryptoStream);
            }
        }
    }
