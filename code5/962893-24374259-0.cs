    using Microsoft.Office.Word.Server.Conversions;
    var fileContent = "<html><body><h1> Blah Blah Blah </h1></body></html>";
    using (var read = GenerateStreamFromString(fileContent))
    using (var write = new MemoryStream())
    using (var site = new SPSite("http://localhost"))
    using (var web = site.OpenWeb())
    {
        var wordAutomationServiceName = "Word Automation Services";
        var sc = new SyncConverter(wordAutomationServiceName);
        sc.UserToken = site.UserToken;
        sc.Settings.UpdateFields = true;
        sc.Settings.OutputFormat = SaveFormat.PDF;
    
        var info = sc.Convert(read, write);
        if (info.Succeeded)
        {
            var folder = web.Lists["Documents"].RootFolder;
            folder.Files.Add("http://localhost/Documents/SyncConverted.pdf", write);
        }
    }
    
    public static Stream GenerateStreamFromString(string s)
    {
        var stream = new MemoryStream();
        var writer = new StreamWriter(stream);
        writer.Write(s);
        writer.Flush();
        stream.Position = 0;
        return stream;
    }
