        public void InsertData()
        {
            var p = new DynamicParameters();
            p.Add("VAR1", "John");
            p.Add("VAR2", "McEnroe");
            p.Add("BASEID", 1);
            p.Add("NEWID", dbType: DbType.Int32, direction: ParameterDirection.Output);
            connection.Query<int>("SP_MYTESTpROC", p, commandType: CommandType.StoredProcedure).First()
            int newID =  p.Get<int>("NEWID");
        }
