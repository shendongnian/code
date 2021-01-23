    public void create()
    {
        List<DataModel> __dataList = new List<DataModel>();
        using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream stream = ISF.CreateFile("Data.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<DataModel>));
                serializer.Serialize(stream, __dataList);            
            }
        }
    }
