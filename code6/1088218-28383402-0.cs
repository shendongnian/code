    public void BackupDatabase(string filePath, string dbName)
    {
        using (CameraManDBEntities dbEntities = new CameraManDBEntities())
        {
            string backupQuery = @"BACKUP DATABASE @DbName TO DISK = N'{0}'";
            backupQuery = string.Format(backupQuery, filePath);
    
            dbEntities.Database.SqlQuery<object>(backupQuery,
                new SqlParameter("DbName", dbName)).ToList().FirstOrDefault();
        }
    }
    
    BackupDatabase(BackUpFileName, "CameraManDB");
