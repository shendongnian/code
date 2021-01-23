    public interface IDataStore
        {
            void Write(Data data);
            Data Read();
        }
    
        public class DataStoreCd : IDataStore
        {
            private static DataStoreCd _instance;
    
            private DataStoreCd()
            {
            }
    
            public static DataStoreCd Instance
            {
                get { return _instance ?? (_instance = new DataStoreCd()); }
            }
    
            public void Write(Data data)
            {
                // implementation
            }
    
            public Data Read()
            {
                // implementation
            }
        }
    
    
        public enum StorageType
        {
            Cd = 0,
            Dvd = 1,
            Hdd = 2
        }
    
        public class DataStoreFactory
        {
            private readonly Dictionary<StorageType, IDataStore> _dataStoresDictionary;
    
            public DataStoreFactory()
            {
                _dataStoresDictionary = new Dictionary<StorageType, IDataStore>
                    {
                        {StorageType.Cd, DataStoreCd.Instance},
                        {StorageType.Dvd, DataStoreDvd.Instance},
                        {StorageType.Hdd, DataStoreHdd.Instance},
                    };
            }
    
            public IDataStore CreateFor(StorageType storageType)
            {
                return _dataStoresDictionary[storageType]; //if you don't have storage type in dictionary
                                                // will throw an exception. You can change it to switch,
                                                // or some better solution
            }
        }
