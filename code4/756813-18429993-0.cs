     public DbConnection GetSqlConn4DbName(string dataSource, string dbName) {
            var sqlConnStringBuilder = new SqlConnectionStringBuilder();
            sqlConnStringBuilder.DataSource = String.IsNullOrEmpty(dataSource) ? DefaultDataSource : dataSource;
            sqlConnStringBuilder.IntegratedSecurity = true;
            sqlConnStringBuilder.MultipleActiveResultSets = true;
            // NOW MY PROVIDER FACTORY OF CHOICE, switch providers here 
            var sqlConnFact = new SqlConnectionFactory(sqlConnStringBuilder.ConnectionString);
            var sqlConn = sqlConnFact.CreateConnection(dbName);
            return sqlConn;
        }
