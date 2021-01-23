    public SqlDataReader comboboxLoad(SqlConnection con)
    {
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandText = "select drugname from drugtab order by drugname";
        return com.ExecuteReader();
    }
