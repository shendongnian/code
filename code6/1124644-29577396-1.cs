    using (var site = new SPSite(url))
    {
        using (var web = site.OpenWeb())
        {
           var list = web.Lists.TryGetList(listTitle);
           var targetFolder =  list.RootFolder;
           var fileContent = System.IO.File.ReadAllBytes(fileName);
           var fileUrl = Path.GetFileName(fileName);
           targetFolder.Files.Add(fileUrl, fileContent);
        }
    }
