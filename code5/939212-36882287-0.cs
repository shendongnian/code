    string fileName = @"C:\AddUser.aspx";
    using (var context = new   ClientContext("https://yourdomain.com"))
            {
                var passWord = new SecureString();
                foreach (var c in "YourPassword") passWord.AppendChar(c);
                context.Credentials = new SharePointOnlineCredentials("YourUsername", passWord);
                var web = context.Web;
                var newFile = new FileCreationInformation { Content = System.IO.File.ReadAllBytes(fileName), Url = Path.GetFileName(fileName) };
                var docs = web.Lists.GetByTitle("Pages");
                Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);
                context.ExecuteQuery();
            }
