        private ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();
        private DataTable RunSelectSQL(string Sql)
        {
            DataTable selectDataTable = null;
            try
            {
                _readerWriterLock.EnterReadLock();                
                //Function to acess your database and return the selected results
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }
            return selectDataTable;
        }
        private DataTable RunInsertSQL(string Sql)
        {
            DataTable selectDataTable = null;
            bool isbreaked = false;
            try
            {
                _readerWriterLock.EnterWriteLock();
                if (_readerWriterLock.WaitingReadCount > 0)
                {
                    isbreaked = true;
                }
                else
                {
                    //Function to insert data in your database
                }
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
            if (isbreaked)
            {
                Thread.Sleep(10);
                return RunInsertSQL(Sql);
            }
            return selectDataTable;
        }
