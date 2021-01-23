    public class SynchronousViewDatabase : IDatabase
    {
        public Data GetData()
        {
            var getDataTask = GetData();
            getDataTask.RunSynchroniously();
            if(getDataTask.Status == TaskStatus.RanToCompletion)
               return getDataTask.Result;
            throw getDataTask.Exception;
        } 
    }
