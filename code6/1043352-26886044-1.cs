    [Conditional("DEBUG")]
    public static void WriteBytesToTempFile(byte[] fileContent)
    {
        var tempFileName = "c:\temp.pdf";
        if (File.Exists(tempFileName))
            File.Delete(tempFileName);
        using (var writer = new BinaryWriter(File.Open(tempFileName, FileMode.Create)))
        {
           writer.Write(fileContent);
        }
     }
