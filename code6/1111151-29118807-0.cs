    using(var myConn = new SqlConnection(conString))
    using(var cmd = myConn.CreateCommand())
    {
        cmd.CommandText = "select distinct a.e_id from tenter where date = @date";
        cmd.Parameters.Add(@date, SqlDbType.DateTime2).Value = DateTime.Now;
        using(var adapter = new SqlDataAdapter(cmd))
        {
           // Do your operations.
        }
    }
