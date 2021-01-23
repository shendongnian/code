    public static class AppSystem
    {
        #region FileExistsMethod
        public static async Task<bool> FileExists(string filename)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            IReadOnlyList<StorageFile> list_of_files = await folder.GetFilesAsync();
            foreach(StorageFile file in list_of_files)
            {
                if (file.DisplayName == "Data")
                    return true;
            }
            return false;
        }
        #endregion
        public static async Task<ObservableCollection<Notes>> GetCollection()
        {
            ObservableCollection<Notes> temp = new ObservableCollection<Notes>();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            if (await AppSystem.FileExists("Data"))
            {
                StorageFile file = await folder.GetFileAsync("Data.txt");
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Notes));
                    temp = (ObservableCollection<Notes>)json.ReadObject(stream);
                }
            }   
            return temp;
        }
        
        public static async void Save(Notes notes)
        {
            ObservableCollection<Notes> temp = new ObservableCollection<Notes>();
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            bool exists = await AppSystem.FileExists("Data");
           
            if(exists==true)
            {
                StorageFile file = await folder.GetFileAsync("Data");
                using(Stream stream = await file.OpenStreamForReadAsync())
                {
                    DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Notes));
                    temp = (ObservableCollection<Notes>)json.ReadObject(stream);
                }
                await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
          
            temp.Add(notes);
            StorageFile file1 = await folder.CreateFileAsync("Data", CreationCollisionOption.ReplaceExisting);
            using(Stream stream = await file1.OpenStreamForWriteAsync())
            {
                DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(Notes));
                json.WriteObject(stream, temp);
            }
        }
    }
