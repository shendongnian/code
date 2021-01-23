        public void TestProcSupport()
        {
            var p = new DynamicParameters();
            p.Add("a", 11);
            p.Add("b", dbType: DbType.Int32, direction: ParameterDirection.Output);
            p.Add("c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            connection.Execute(@"create proc #TestProc 
	                         @a int,
                                 @b int output
                                 as 
                                 begin
                                     set @b = 999
                                     select 1111
                                     return @a
                                 end");
            connection.Query<int>("#TestProc", p, commandType: CommandType.StoredProcedure).First().IsEqualTo(1111);
            p.Get<int>("c").IsEqualTo(11);
            p.Get<int>("b").IsEqualTo(999);
        }
