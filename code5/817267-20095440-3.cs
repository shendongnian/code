    [DataContractAttribute]
    [KnownType (typeof(List<String>))]
    public class SerializableObject
    {
       [DataMember]
        public List<String> serFile { get; set; }
    }
    public static Object GetFile(String FileName)
    {
        try
        {
          if (!IsolatedStorageFile.GetUserStoreForApplication().FileExists(FileName))
           {
             throw new System.ArgumentException("File Doesn't Exist In Isoloated Storage");
           }
        }
        catch { return null;  }
    
        Object ret = new Object();
        try
        {
          IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication();
    
          IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication();
          IsolatedStorageFileStream fileStream = myIsolatedStorage.OpenFile(@"\" + FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    
    
          SerializableObject serList = new SerializableObject();
          DataContractSerializer dsc = new DataContractSerializer(serList.GetType());
          ret = ((SerializableObject)dsc.ReadObject(fileStream)).serFile;
        }
        catch (Exception error) { throw new System.ArgumentException(error.Message); }
        return ret;
    }
