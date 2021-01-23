    using(SqlConnection conn = new SqlConnection(ConnectionData[1])
    {
        using(SqlCommand cmd = new SqlCommand(ConnectionData[0], conn)
        {                                                     // ^-- re-use connection - see comment below
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < args.Length; i++)
            {
                SqlParameter Param = new SqlParameter(ConnectionData[i + 2], DBNullIfNull(args[i]));
                cmd.Parameters.Add(Param);
            }
            cmd.Connection.Open();
            DataTable dt = new DataTable();
            using (dr = cmd.ExecuteReader())
            {
                if (dr != null)
                    dt.Load(dr);
                else
                    dt = null;
            }
            return dt;
        }    
    }
