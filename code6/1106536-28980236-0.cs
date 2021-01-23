    using(var clientContext = new ClientContext(site))
    {
         Web web = clientContext.Web;
         Microsoft.SharePoint.Client.File file = web.GetFileByServerRelativeUrl("/site/doclib/folder/filename.ext");
         bool bExists = false;
         try
         {
             clientContext.Load(file);
             clientContext.ExecuteQuery(); //Raises exception if the file doesn't exist
             bExists = file.Exists;  //may not be needed - here for good measure
         }
         catch{   }
         if (bExists )
         {
               .
               .
         }
    }
