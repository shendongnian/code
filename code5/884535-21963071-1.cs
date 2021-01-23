        public void GetImages()
        {
            using (MediaLibrary library = new MediaLibrary())
            {
                var savedPictures = library.RootPictureAlbum.Albums.First(a => a.Name == "Saved Pictures");
        
                _pictures = savedPictures.Pictures.OrderByDescending(p => p.Date).ToList();
            }
        }
