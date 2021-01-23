    public IEnumerable<DBBackupConfiguration> GetAllConfiguration()
            {
            var result = m_db.DBBackupConfigurations.Where(c => c.BackupStatus == 1).OrderByDescending(c => c.ConfigurationId).ToList();
                return result;
            }
