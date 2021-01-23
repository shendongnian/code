    public sealed class FileShareAccessFactory : IFileShareAccessFactory
    {
        private static IFileShareAccess m_fileShareAccess;
        private static readonly object m_SyncRoot = new object();
    
        public IFileShareAccess GetFileShareAccessInstance(IContextFactory contextFactory, ILogger logger)
        {
           lock (m_SyncRoot)
                {
                    if (m_fileShareAccess == null)
                    {
                        m_fileShareAccess = new FileShareAccess(contextFactory, logger);
                    }
            return m_fileShareAccess;
                }
        }
    }
