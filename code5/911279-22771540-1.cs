            const string sql = "insert into files set data = @data where Name = @name";
            using (var cn = _db.CreateConnection())
            using (var cm = cn.CreateTextCommand(sql))
            {
                cm.AddInParam("name", DbType.String, name);
                cm.AddInParam("data", DbType.Binary, data);
                cm.ExecuteNonQuery();
            }
