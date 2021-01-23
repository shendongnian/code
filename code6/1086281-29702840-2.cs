    using (var ctx = ClientContext(webUri))
    {        
       //find content type
       var result = ctx.LoadQuery(ctx.Site.RootWeb.AvailableContentTypes.Where(ct => ct.Name == "Order Document"));
       ctx.ExecuteQuery();
       if (result.Any())
       {
           var ctId = result.First().Id.StringValue;
           var siteFields = ctx.Site.RootWeb.Fields;
           var fieldToDel = siteFields.GetByInternalNameOrTitle(fieldName);
           fieldToDel.DeleteObject(ctId);
           ctx.ExecuteQuery();
       }
    }
