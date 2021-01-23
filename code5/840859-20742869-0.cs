    if (Request.Files.AllKeys.Any())
         {
            var key = Request.Files.AllKeys.First();
            fullSizeImage = new WebImage(Request.Files[key].InputStream);
          }
          else
          {
             fullSizeImage = new WebImage(Request.InputStream);
          }
