    client.PostCompleted +=
                            new EventHandler<LiveOperationCompletedEventArgs>(CreateMyFolder_Completed);
     void CreateMyFolder_Completed(object sender, LiveOperationCompletedEventArgs e)
            {
                if (e.Error == null)
                {
                   string folderID = (e.Result["id"]).ToString();
                    foreach (string item in names)
                    {
                        using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
                        {
                            string filename = item;
                            if (store.FileExists(filename))
                            {
                                IsolatedStorageFileStream storeStream = store.OpenFile(filename, FileMode.Open, FileAccess.Read);
                                client.UploadAsync(folderID, filename, storeStream, OverwriteOption.Overwrite);
    
                            }                         
                        }
                    }
                }
