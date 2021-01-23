    public void CopyFiles(string sourcePath, string destinationPath)
        {
            string[] files = System.IO.Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath(sourcePath));
            foreach (var file in files)
	        {
	            string filePath = System.Web.HttpContext.Current.Server.MapPath(destinationPath).ToString();
                System.IO.File.Copy(file, System.IO.Path.Combine(filePath, System.IO.Path.GetFileName(file)));
            };
        }
   
  
 
