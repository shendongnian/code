    public void SaveFileToSharePoint(string fileName)
    {
        using (var context = new ClientContext("https://mydomain.com/"))
        {
            var passWord = new SecureString();
            foreach (var c in "MyPassword") passWord.AppendChar(c);
            context.Credentials = new SharePointOnlineCredentials("me@mydomain.com", passWord);
            var web = context.Web;
            var newFile = new FileCreationInformation {Content = File.ReadAllBytes(fileName), Url = Path.GetFileName(fileName)};
            var docs = web.Lists.GetByTitle("Documents");
            docs.RootFolder.Folders.GetByUrl("Test").Files.Add(newFile);
            context.ExecuteQuery();
        }
    }
    public void GetFileFromSharePoint(string fileName, string savePath)
    {
        using (var context = new ClientContext("https://mydomain.com/"))
        {
            var passWord = new SecureString();
            foreach (var c in "MyPassword") passWord.AppendChar(c);
            context.Credentials = new SharePointOnlineCredentials("me@mydomain.com", passWord);
            var web = context.Web;
            var myFile = web.Lists.GetByTitle("Documents").RootFolder.Folders.GetByUrl("Test").Files.GetByUrl(fileName);
            context.Load(myFile);
            context.ExecuteQuery();
            using (var ffl = Microsoft.SharePoint.Client.File.OpenBinaryDirect(context, myFile.ServerRelativeUrl))
            {
                using (var destFile = File.OpenWrite(savePath + fileName))
                {
                    var buffer = new byte[8*1024];
                    int len;
                    while ((len = ffl.Stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destFile.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
