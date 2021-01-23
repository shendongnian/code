            StorageFolder musicFolder = KnownFolders.MusicLibrary;
            IReadOnlyList<StorageFile> fileList = await musicFolder.GetFilesAsync();
            foreach (var file in fileList)
            {
                MusicProperties musicProperties = await file.Properties.GetMusicPropertiesAsync();
               Debug.WriteLine("Album: " + musicProperties.Album);
               Debug.WriteLine("Rating: " + musicProperties.Rating);
               Debug.WriteLine("Producers: " + musicProperties.Publisher);
            }
