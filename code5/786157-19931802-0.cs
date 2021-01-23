    IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(
          IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
    byte[] byteArray = Convert.FromBase64String(data);                    
    IsolatedStorageFileStream stream = new IsolatedStorageFileStream("myfile", 
          FileMode.Create, isoStore);
    stream.Write(byteArray, 0, byteArray.Length);
    stream.Close();
