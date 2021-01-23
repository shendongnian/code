    void saveInBinary(object o)
    {
        IFormatter binaryFormatter = new BinaryFormatter();
        Stream binaryStream = new FileStream("File Path Here", FileMode.Create, FileAccess.Write, FileShare.None);
        binaryFormatter.Serialize(binaryStream, o);
        binaryStream.Close();
    }
