      public static void writeisobtn_Click(string filename)
        {
            MyDataList listobj = new MyDataList();
            using (IsolatedStorageFileStream fileStream = Settings1.OpenFile("MyStoreItems", FileMode.Open))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(MyDataList));
                listobj = (MyDataList)serializer.ReadObject(fileStream);
            }     
            listobj.Add(new MyData { Name = filename });
            using (IsolatedStorageFileStream fileStream = Settings1.OpenFile("MyStoreItems", FileMode.OpenOrCreate))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(MyDataList));
                serializer.WriteObject(fileStream, listobj);
            }
            MessageBox.Show("Items stored successfully.");
        }
