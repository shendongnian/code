    using (ClientContext clientContext = new ClientContext("SHAREPOINT URL"))
                {
                    SecureString passWord = new SecureString();
                    foreach (char c in "PASSWORD".ToCharArray()) passWord.AppendChar(c);
                    clientContext.Credentials = new SharePointOnlineCredentials("ACOUNT.onmicrosoft.com", passWord);
                    Web web = clientContext.Web; 
                    FileCreationInformation newFile = new FileCreationInformation();
                    newFile.Content = System.IO.File.ReadAllBytes(FILE);
                    newFile.Url = NAMEFORTHEFILE;
                    
                    List docs = web.Lists.GetByTitle("LIBRARY NAME");
                    Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);
                    clientContext.ExecuteQuery();
