    class Album {
        public Album (List<Photo> photos)
        {
            if (photos.Count < 1)
            {
                throw new Exception("Album must have at least one photo.");
            }
            foreach (Photo thisPhoto in photos)
            {
                thisPhoto.setAlbum(this);
            }
        }
    }
