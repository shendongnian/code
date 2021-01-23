    public string sample(DateTime fdate)
    {
        string qry = "insert into sample values( @date )";
        using (var cn = new SqlConnection("connection string here") )
        using (var cmd = new SqlCommand(qry, cn))
        {
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = fdate;
            cn.Open();
            using (var dr = cmd.ExecuteReader())
            {
                //use dr here...
            }
        }
    }
