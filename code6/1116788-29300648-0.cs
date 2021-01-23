    public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            string savepath = "", tempPath = "";
            context.Response.ContentType = "text/plain";
            tempPath = System.Configuration.ConfigurationManager.AppSettings["YourFilePath"];
            savepath = context.Server.MapPath(tempPath);
            string extension = System.IO.Path.GetExtension(postedFile.FileName);
            string filename = System.IO.Path.GetFileNameWithoutExtension(postedFile.FileName) + extension;
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
            System.IO.File.Delete(savepath + @"\" + filename);
            postedFile.SaveAs(savepath + @"\" + filename);
        }
