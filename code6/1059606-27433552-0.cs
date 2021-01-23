    [WebMethod]
        public void AttachFiles()
        {
            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            using (var fileStream = new System.IO.FileStream(AppDomain.CurrentDomain.BaseDirectory+file.FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                file.InputStream.CopyTo(fileStream);
            }
        }
