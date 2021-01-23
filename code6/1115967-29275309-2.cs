    public static class clsUploadFile
    {
        public static string uploadFile(HttpPostedFileBase file, string UploadPath)
        {
            string imgPath = null;
            //var fileName = DateTime.Now.ToString();
            //fileName = fileName.Replace(" ", "_");
            //fileName = fileName.Replace("/", "_");
            //fileName = fileName.Replace(":", "_");
            string fileName = System.IO.Path.GetRandomFileName();
            fileName = fileName.Replace(".", "");
            var ext = System.IO.Path.GetExtension(file.FileName);
            fileName += ext;
            System.IO.DirectoryInfo dr = new System.IO.DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath("~" + UploadPath));
            System.IO.FileInfo[] files = dr.GetFiles();
            for(;true;)
            {
                if (!files.Where(o => o.Name.Equals(fileName)).Any())
                    break;
                else
                {
                    fileName = System.IO.Path.GetRandomFileName();
                    fileName = fileName.Replace(".", "");
                    fileName += ext;
                }
            }
            var path = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~" + UploadPath), fileName);
            file.SaveAs(path);
            imgPath = UploadPath + fileName;
            return imgPath;
        }
        public static bool DeleteFile(string path)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(System.Web.HttpContext.Current.Server.MapPath(path));
            if (file.Exists)
            {
                file.Delete();
                return true;
            }
            else
                return false;
        }
    }
