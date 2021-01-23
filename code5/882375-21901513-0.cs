    IDbCommand cmd = connection.CreateCommand(); //connection has been instantiated
    cmd.CommandTimeout = connection.ConnectionTimeout;
    var query = @"SELECT COUNT(emp_num)
    	          FROM tbl1 WHERE year IS NULL AND calc_year = @year AND camp IN ({0})";
    cmd.Parameters.Add(new SqlParameter("@year", calcYear));
    var sb = new StringBuilder();
    //ids is a list/array of ids i want in the in clause
    for (int i = 0; i < ids.Count; i++)
    {
       sb.AppendFormat("@p{0},", i);
       cmd.Parameters.Add(new SqlParameter("@p" + i, ids[i]));
    }
    if (sb.Length > 0) { sb.Length -= 1; }
    string cmdText = string.Format(query, sb.ToString());
    cmd.CommandText = cmdText;
    cmd.Connection = connection;
    var reader = cmd.ExecuteReader();
