    using (var ctx = GetSPOContext(webUri,userName,password))
    {
         var list = ctx.Web.Lists.GetByTitle(listTitle);
         if(FileExists(list,"/documents/SharePoint User Guide.docx"))
         {
              //...
         }
    }
