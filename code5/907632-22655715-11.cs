    {
       
        public void ProcessRequest(HttpContext context)
        {
            
            if (context.Request.Files.Count > 0)
            {
                string path = context.Server.MapPath("~/UploadImages");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
    
                var file = context.Request.Files[0];
    
                string fileName;
    
                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                {
                    string[] files = file.FileName.Split(new char[] { '\\' });
                    fileName = files[files.Length - 1];
                }
                else
                {
                    fileName = file.FileName;
                }
                string newFilename = Guid.NewGuid().ToString();
                FileInfo fInfo = new FileInfo(fileName);
                newFilename = string.Format("{0}{1}", newFilename, fInfo.Extension);
                string strFileName = newFilename;
                fileName = Path.Combine(path, newFilename);
                file.SaveAs(fileName);
    
    
                string msg = "{";
                msg += string.Format("error:'{0}',\n", string.Empty);
                msg += string.Format("msg:'{0}'\n", strFileName);
                msg += "}";
                context.Response.Write(msg);
    
    
            }
        }
        
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
