    public bool ByteArrayToFile(string fileName, byte[] byteArray)
    {
       System.IO.File.WriteAllBytes(fileName, byteArray);
       return true;
    }
