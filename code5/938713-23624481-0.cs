        ClientContext context = new ClientContext("yoursite");
        Web web = context.Web;
        FileCreationInformation newFile = new FileCreationInformation();
        newFile.Content = System.IO.File.ReadAllBytes(file);
        newFile.Url = System.IO.Path.GetFileName(file);
        List docs = web.Lists.GetByTitle("LibName");
        Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);
        context.Load(uploadFile);
        context.ExecuteQuery();
    }
