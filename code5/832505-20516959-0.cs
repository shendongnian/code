    public void AppendAllBytes(string path, byte[] bytes)
    {
        var fileName = @"C:\\Users\\life.monkey\\Desktop\\B\\New folder (2)\\aaaaaaaaaaaaaaaaaaaaaaaaaaa.docx.aef";
        using (var encryptedFile = new FileStream(path, FileMode.Open, FileAccess.Read))
        using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Append)))
        using (var result = new MemoryStream())
        {
            encryptedFile.CopyTo(result);
            result.Flush(); // ensure header is entirely written.
            // write header directly, no need to put it in the memory stream
            writer.Write(bytes);
            writer.Flush(); // ensure the header is written to the result stream.
            writer.Write(result.ToArray());
            writer.Flush(); // ensure the encryptdFile is written to the result stream.
        }
    }
 
