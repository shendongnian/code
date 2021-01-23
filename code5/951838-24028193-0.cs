     private string getImagePath(int imageId)
     {
            var connectionString = ConfigurationManager.ConnectionStrings["theImageDataBase"].ConnectionString;
            var theAlbum = "searchTerm";
            List<string> images = Fetcher.getImagePaths(connectionString, theAlbum);
            foreach (var image in images)
                Response.WriteLine(image);
            return "";
     }
