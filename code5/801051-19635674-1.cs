          public void create()
      {
         List<DataModel> __dataList = new List<DataModel>();
         //XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
         //xmlWriterSettings.Indent = true;
         using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
         {
            using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Data.xml", FileMode.Create))
            {
               try
               {
                  XmlSerializer serializer = new XmlSerializer(typeof(List<DataModel>));
                  //using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                  //{
                  serializer.Serialize(stream, __dataList);
                  //}
               }
               catch { }
            }
         }
      }
      public void read()
      {
         List<DataModel> __dataList = new List<DataModel>();
         try
         {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
               using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("Data.xml", FileMode.Open))
               {
                  XmlSerializer serializer = new XmlSerializer(typeof(List<DataModel>));
                  __dataList = (List<DataModel>)serializer.Deserialize(stream);
               }
            }
         }
         catch (Exception e)
         {
            string s = e.Message;
            e.ToString();
         }
      }
