    public class Usage
    {
        public void TestUsage()
        {
            var dataStoreExecutable = new DataStoreExecutable();
            var data = new Data();
            dataStoreExecutable.Write(data, StorageType.Cd);
        }
    }
