    ClientContext context = new ClientContext("<websiteurl>");
    Web web = context.Web;
    context.Load(web);
    context.ExecuteQuery();
    var q = from list in web.Lists
                    where <put condition here>
                    select list;
    var r = context.LoadQuery(q);
    context.ExecuteQuery();
    foreach (var list in r)
    {
       context.Load(list.RootFolder);
       context.ExecuteQuery();
       ...
       //To get folders
       GetFolders(context, list.Root.Folders);
       //To get files
       GetFiles(context, list.RootFolder.Files);
     }
