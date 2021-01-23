        DbProviderFactory dbFactory;
        private DatabaseTypes m_dbType;
        public DatabaseTypes DbType
        {
            get { return m_dbType; }
            set 
            {
                m_dbType = value;
                dbFactory = DbProviderFactories.GetFactory(DatabaseProvider.GetDatabaseProvider(m_dbType));
            }
        }
