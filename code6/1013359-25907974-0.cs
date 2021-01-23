          CopyFiles("/1.jpg", "/TestFolder");
  
     public void CopyFiles(string sourcePath, string destinationPath)
        {
	            string filePath = System.Web.HttpContext.Current.Server.MapPath(destinationPath).ToString();
                sourcePath = System.Web.HttpContext.Current.Server.MapPath(sourcePath);
                System.IO.File.Copy(sourcePath, System.IO.Path.Combine(filePath, System.IO.Path.GetFileName(sourcePath)));
        }
