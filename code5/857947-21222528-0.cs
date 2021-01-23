     [WebMethod]
        public string UploadFile(byte[] f, string fileName)
        {
            try
            {
                MemoryStream ms = new MemoryStream(f);
                FileStream fs = new FileStream
                   (System.Web.Hosting.HostingEnvironment.MapPath("~/ArchiveImages/") +
                   fileName, FileMode.Create);
                ms.WriteTo(fs);
                ms.Close();
                fs.Close();
                fs.Dispose();
                return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        } 
