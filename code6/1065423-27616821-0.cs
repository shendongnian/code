    public static void SerializeObject(string filename, object objectToSerialize)
    {
        using (Stream stream = File.Open(filename, FileMode.Create))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream cryptoStream = new CryptoStream(stream, cryptic.CreateEncryptor(), CryptoStreamMode.Write))
            {
                binaryFormatter.Serialize(cryptoStream, objectToSerialize);
            }
        }
    }
