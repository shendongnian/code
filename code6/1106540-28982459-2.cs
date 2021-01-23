      public static bool TryGetFileByServerRelativeUrl(Web web, string serverRelativeUrl,out Microsoft.SharePoint.Client.File file)
        {
            var ctx = web.Context;
            try{
                file = web.GetFileByServerRelativeUrl(serverRelativeUrl);
                ctx.Load(file);
                ctx.ExecuteQuery();
                return true;
            }
            catch(Microsoft.SharePoint.Client.ServerException ex){
                if (ex.ServerErrorTypeName == "System.IO.FileNotFoundException")
                {
                    file = null;
                    return false;
                }
                else
                    throw;
            }
        }
