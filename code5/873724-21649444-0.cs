       var path= Server.MapPath("~/ImagesDirectory");
    
       if (!System.IO.Directory.Exists(path))
       {
           System.IO.Directory.CreateDirectory(path);
       }
