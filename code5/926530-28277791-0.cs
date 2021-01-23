            string connectionString = "server=xx.xx.xx.xx;Trusted_Connection=false;user id=user;password=passowrd;database=DBName;Connect Timeout=360;";
            var sqlConnection = new SqlConnection(connectionString);
            var command = sqlConnection.CreateCommand();
        
            Castle.DynamicProxy.Generators.AttributesToAvoidReplicating.Add(typeof(System.Data.SqlClient.SqlClientPermissionAttribute));
            DataSet dsResult = new DataSet();
            dsResult.Tables.Add(new DataTable());
            dsResult.Tables[0].Columns.Add("Column1");           
            DataRow dr = dsResult.Tables[0].NewRow();
            dsResult.Tables[0].Rows.Add(dr);
            dsResult.Tables[0].Rows[0].ItemArray = new object[] { DBNull.Value};
            dsResult.Tables.Add(new DataTable());      
          
            var mockDb = new Mock<SqlDatabase>(connectionString);
            mockDb.Setup(a => a.GetStoredProcCommand("SP_NAME")).Returns(command);
            mockDb.Setup(a => a.ExecuteDataSet(command)).Returns(dsResult);
