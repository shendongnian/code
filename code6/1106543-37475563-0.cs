    using (ClientContext ctx = new ClientContext("https://yoursubdomainhere.sharepoint.com/"))
    {
        Web web = ctx.Web;
        Microsoft.SharePoint.Client.File checkFile = web.GetFileByServerRelativeUrl("/sites/Documents/MyFile.docx");
        ctx.Load(checkFile, fe => fe.Exists);
        ctx.ExecuteQuery();
        if (!checkFile.Exists)
        {
            //Do something here
        }
    }
