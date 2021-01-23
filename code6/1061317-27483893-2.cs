    public static void Main()
    {
        var fileContent = Encoding.UTF8.GetBytes(
            @"{
                ""fruit"":""apple"",
                ""taste"":""yummy""
              }"
            );
        var zipContent = new MemoryStream();
        var archive = new ZipArchive(zipContent, ZipArchiveMode.Create);
        AddEntry("file1.json",fileContent,archive);
        AddEntry("file2.json",fileContent,archive); //second file (same content)
        archive.Dispose();
        File.WriteAllBytes("testa.zip",zipContent.ToArray());
    }
    private static void AddEntry(string fileName, byte[] fileContent,ZipArchive archive)
    {
        var entry = archive.CreateEntry(fileName);
        using (var stream = entry.Open())
            stream.Write(fileContent, 0, fileContent.Length);
    }
