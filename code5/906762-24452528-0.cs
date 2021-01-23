    var folders = new Dictionary<string,Microsoft.SharePoint.Client.Folder>();
    var folderNames = new[] {"Orders","Requests"};
    foreach (var folderName in  folderNames)
    {
       var folderKey = string.Format("/Shared Documents/{0}", folderName);
       folders[folderKey] = context.Web.GetFolderByServerRelativeUrl(folderKey);
       context.Load(folders[folderKey],f => f.Files);
    }
    context.ExecuteQuery();  //execute request only once
            
    //print all files
    var allFiles = folders.SelectMany(folder => folder.Value.Files);
    foreach (var file in allFiles)
    {
       Console.WriteLine(file.Name);
    }
