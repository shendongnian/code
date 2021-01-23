    class IndexReaderFactory :
      IDisposable
    {
      public IndexReaderFactory(bool isReadonly)
      {
        this.isReadonly = isReadonly;
      }
    
      IndexReader reader;
      readonly ReaderWriterLockSlim rwl = new ReaderWriterLockSlim();
      private readonly bool isReadonly;
    
      /// <summary>
      /// Returns a reader that isCurrent
      /// </summary>
      public IndexReader GetUpToDateReader()
      {
        rwl.EnterUpgradeableReadLock();
    
        try
        {
          if (reader == null)
          {
            rwl.EnterWriteLock();
    
            try
            {
              if (logger.IsInfoEnabled)
                logger.Info("Creating IndexReader on directory {0}", AppSettingsBase.LucenePostIndexLocation);
    
              reader = IndexReader.Open(FSDirectory.Open(AppSettingsBase.LucenePostIndexLocation), isReadonly);
            }
    
            finally
            {
              rwl.ExitWriteLock();
            }
          }
    
          else if(!reader.IsCurrent())
          {
            rwl.EnterWriteLock();
    
            try
            {
              if (logger.IsInfoEnabled)
                logger.Info("IndexReader is not current. Re-opening");
    
              reader = reader.Reopen();
            }
    
            finally
            {
              rwl.ExitWriteLock();
            }
          }
        }
    
        finally 
        {
          rwl.ExitUpgradeableReadLock();
        }
    
        return reader;
      }
    
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
    
      public void Dispose(bool disposing)
      {
        if (disposing)
        {
          // get rid of managed resources
        }
    
        if(reader != null)
          reader.Dispose();
      }
    }
