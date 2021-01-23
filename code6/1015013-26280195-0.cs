    public void BackupDatabase(string filePath)
        {
            using (TVend2014Entities dbEntities = new TVend2014Entities(BaseData.ConnectionString))
            {
                string backupQuery = @"BACKUP DATABASE ""{0}"" TO DISK = N'{1}'";
                backupQuery = string.Format(backupQuery, "full databsase file path like C:\tempDb.mdf", filePath);
                dbEntities.Database.SqlQuery<object>(backupQuery).ToList().FirstOrDefault();
            }
        }
        public void RestoreDatabase(string filePath)
        {
            using (TVend2014Entities dbEntities = new TVend2014Entities(BaseData.ConnectionString))
            {
                string restoreQuery = @"USE [Master]; 
                                                    ALTER DATABASE ""{0}"" SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                                                    RESTORE DATABASE ""{0}"" FROM DISK='{1}' WITH REPLACE;
                                                    ALTER DATABASE ""{0}"" SET MULTI_USER;";
                restoreQuery = string.Format(restoreQuery, "full db file path", filePath);
                var list = dbEntities.Database.SqlQuery<object>(restoreQuery).ToList();
                var resut = list.FirstOrDefault();
            }
        }
