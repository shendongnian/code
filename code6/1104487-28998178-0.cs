    using (var ctx =  new ClientContext(webUri))
    {
       var web = ctx.Web;
       var folder = web.GetFolderByServerRelativeUrl("/site/Documents/folder/sub folder");
       var listItem = folder.ListItemAllFields;
       listItem["PropertyName"] = "PropertyValue";
       listItem.Update();
       ctx.ExecuteQuery();
    }
