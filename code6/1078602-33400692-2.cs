    foreach(MigrationStatement ms in res)
    {
        //ms.Sql = ms.Sql.Replace("dbo.","");
        if(ms.Sql.Contains("dbo."))
        {
            return new List<MigrationStatement>();
        }
    }
