    public static void SendDataByteFileToClient(HttpContext context, byte[] data, string fileName, string contentType, bool clearHeaders = true)
            {
   
                if (clearHeaders)
                {
                    context.Response.Clear();
                    context.Response.ClearHeaders();
                }
           
                context.Response.BufferOutput = true;
                context.Response.ContentType = contentType;
    
                context.Response.AddHeader("Content-Disposition", "inline; filename=" + fileName);
                context.Response.AddHeader("Content-Length", data.Length.ToString());
    
                if (BrowserHelper.IsOfType(BrowserTypeEnum.IE) && BrowserHelper.Version < 9)
                {
                    context.Response.Cache.SetCacheability(HttpCacheability.Private);
                    context.Response.Cache.SetMaxAge(TimeSpan.FromMilliseconds(1));
                }
                else
                {
                    context.Response.Cache.SetCacheability(HttpCacheability.NoCache);//IE set to not cache
                    context.Response.Cache.SetNoStore();//Firefox/Chrome not to cache
                    context.Response.Cache.SetExpires(DateTime.UtcNow); //for safe measure expire it immediately
                }
    
                if (data.Length > 0)
                {
                    context.Response.BinaryWrite(data);
                }
    
                context.Response.End();
            }
