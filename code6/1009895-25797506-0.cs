    public class DataAccess
    {
        private Task<MyData> _getDataTask;
        private readonly object lockObj = new Object();
        public async Task<MyData> GetDataAsync()
        {
            lock(lockObj)
            {
                if (_getDataTask == null)
                {
                    _getDataTask = Task.Run(() => synchronousDataAccessMethod());
                }
            }
            return await _getDataTask;
        }
    }
