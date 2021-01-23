            //var Db = DbFactory.OpenDbConnection(); // I already have Db as IDbConnection from 'RepositoryBase'
            using (var dbCmd = Db.OpenCommand())
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = "dbo.StoredProcName";
                dbCmd.Parameters.Add(new SqlParameter("@tvpName", dataTableTmp));
                dbCmd.ExecuteNonQuery();
            }
