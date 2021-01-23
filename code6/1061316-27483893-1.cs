    public static void Main()
    {
        var fileContent = Encoding.UTF8.GetBytes(
            @"{
                ""fruit"":""apple"",
                ""taste"":""yummy""
              }"
            );
        var zipStream = new MemoryStream();
        var zip = new ZipOutputStream(zipStream);
        AddEntry("file0.json", fileContent, zip); //first file
        AddEntry("file1.json", fileContent, zip); //second file (with same content)
        zip.Close();
        //only for testing to see if the zip file is valid!
        File.WriteAllBytes("test.zip", zipStream.ToArray());
    }
    private static void AddEntry(string fileName, byte[] fileContent, ZipOutputStream zip)
    {
        var zipEntry = new ZipEntry(fileName) {DateTime = DateTime.Now, Size = fileContent.Length};
        zip.PutNextEntry(zipEntry);
        zip.Write(fileContent, 0, fileContent.Length);
        zip.CloseEntry();
    }
