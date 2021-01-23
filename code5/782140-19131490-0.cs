    using(ClientContext context = new ClientContext("http://yourURL"))
    {
	Web web = context.Web;
	FileCreationInformation newFile = new FileCreationInformation();
	newFile.Content = System.IO.File.ReadAllBytes(@"C:\myfile.txt");
	newFile.Url = "file uploaded via client OM.txt";
	List docs = web.Lists.GetByTitle("Documents");
	Microsoft.SharePoint.Client.File uploadFile = docs.RootFolder.Files.Add(newFile);	
	context.ExecuteQuery();
    }
