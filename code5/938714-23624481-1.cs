    public void UploadFileToSharePoint(string filePath)
    {
            ClientContext context = new ClientContext("yoursite");
            Web web = context.Web;
    
            FileCreationInformation newFile = new FileCreationInformation();
            newFile.Content = System.IO.File.ReadAllBytes(filePath);
            newFile.Url = System.IO.Path.GetFileName(filePath);
    
            List docs = web.Lists.GetByTitle("LibName");
            Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);
    
            context.Load(uploadFile);
    
            context.ExecuteQuery();
    }
