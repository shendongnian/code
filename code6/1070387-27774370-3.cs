    Parallel.ForEach(dt.Rows,
        () =>
        {
            var con = new SqlConnection();
            var cmd = con.CreateCommand();
            cmd.CommandText = sql_proc;
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.Add(new SqlParameter("@a", SqlDbType.Int));
            // NB : Size sensitive parameters must have size
            cmd.Parameters.Add(new SqlParameter("@b", SqlDbType.VarChar, 100));
            cmd.Parameters.Add(new SqlParameter("@c", SqlDbType.Bit));
            // Prepare won't help with SPROCs but can improve plan caching for adhoc sql
            // cmd.Prepare();
            return new {Conn = con, Cmd = cmd};
        },
        (dr, pls, localInit) =>
        {
            localInit.Cmd.Parameters["@a"] = dr["a"];
            localInit.Cmd.Parameters["@b"] = dr["b"];
            localInit.Cmd.Parameters["@c"] = dr["c"];
            localInit.Cmd.ExecuteNonQuery();
            return localInit;
        },
        (localInit) =>
        {
            localInit.Cmd.Dispose();
            localInit.Conn.Dispose();
        });
