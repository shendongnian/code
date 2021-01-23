    private void AddSong()
        {
            Uri file = new Uri("Assets/someSong.mp3", UriKind.Relative);
            //copy file to isolated storage
            var myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
            var fileStream = myIsolatedStorage.CreateFile("someSong.mp3");
            var resource = Application.GetResourceStream(file);
            int chunkSize = 4096;
            byte[] bytes = new byte[chunkSize];
            int byteCount;
            while ((byteCount = resource.Stream.Read(bytes, 0, chunkSize)) > 0)
            {
                fileStream.Write(bytes, 0, byteCount);
            }
            fileStream.Close();
            Microsoft.Xna.Framework.Media.PhoneExtensions.SongMetadata metaData = new Microsoft.Xna.Framework.Media.PhoneExtensions.SongMetadata();
            metaData.AlbumName = "Some Album name";
            metaData.ArtistName = "Some Artist Name";
            metaData.GenreName = "test";
            metaData.Name = "someSongName";
            var ml = new MediaLibrary();
            Uri songUri = new Uri("someSong.mp3", UriKind.RelativeOrAbsolute);
            var song = Microsoft.Xna.Framework.Media.PhoneExtensions.MediaLibraryExtensions.SaveSong(ml, songUri, metaData, Microsoft.Xna.Framework.Media.PhoneExtensions.SaveSongOperation.CopyToLibrary);            
        }
