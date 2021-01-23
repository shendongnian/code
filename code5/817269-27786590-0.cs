     List<DataModel> dataList = new List<DataModel>();
             using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
             {
                 using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                 {
                     XmlSerializer serializer = new XmlSerializer(typeof(List<DataModel>));
                     dataList = (List<DataModel>)serializer.Deserialize(stream);
                 }
               
            }
