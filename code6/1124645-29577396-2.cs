    using (var ctx = new ClientContext(url))
    {
         ctx.Credentials = new NetworkCredential(userName, password, domain);
         using (var fs = new FileStream(fileName, FileMode.Open))
         {
             var fi = new FileInfo(fileName);
             var list = ctx.Web.Lists.GetByTitle(listTitle);
             ctx.Load(list.RootFolder);
             ctx.ExecuteQuery();
             var fileUrl = String.Format("{0}/{1}", list.RootFolder.ServerRelativeUrl, fi.Name);
    
             Microsoft.SharePoint.Client.File.SaveBinaryDirect(ctx, fileUrl, fs, true);
         }
    }
