    using(SqlConnection cnn = new SqlConnection(....here the connection string ....))
    using(SqlCommand cmd = new SqlCommand("uspRetMostCommonScreenRes", cnn))
    {
        cnn.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        string result = cmd.ExecuteScalar().ToString();
    }
