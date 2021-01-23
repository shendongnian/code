        private async void MyButton_Click(object sender, RoutedEventArgs e)
        {
            string cssDocument = "body{font-family:\"Arial\";}";
            // using Windows.Storage
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            folder = await folder.CreateFolderAsync("HTML", CreationCollisionOption.OpenIfExists);
            folder = await folder.CreateFolderAsync("CSS", CreationCollisionOption.OpenIfExists);
            StorageFile file = await folder.CreateFileAsync("style.css", CreationCollisionOption.ReplaceExisting);
            using (var writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(cssDocument);
            }
            // using using System.IO.IsolatedStorage;
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!store.DirectoryExists("HTML/CSS"))
                    store.CreateDirectory("HTML/CSS");
                using (var writer = new StreamWriter(store.OpenFile("HTML/CSS/style.css", FileMode.Create)))
                {
                    writer.Write(cssDocument);
                }
            }
            changeStyle(new FontFamily("Arial"));
        }
