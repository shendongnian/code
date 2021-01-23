            const string sql = "select data from files where name = @name";
            using (var cn = _db.CreateConnection())
            using (var cm = cn.CreateTextCommand(sql))
            {
                cm.AddInParam("name", DbType.String, name);
                cn.Open();
                return cm.ExecuteScalar() as byte[];
            }
