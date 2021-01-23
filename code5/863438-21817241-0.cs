    public class DBconnection : IDisposable
    {
        private ChatEntities _db = new ChatEntities();
        protected ChatEntities Db {
            get { return _db; }
        }
        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
