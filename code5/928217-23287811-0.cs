    public DataSet getByFloor(int floorNo)
    {
        DataSet ds = new DataSet();
        SqlConnection conn = connectionCls.openConnection();
        SqlCommand com = new SqlCommand("select * from table where floorsNo = @floorsNo", conn);
        com.Parameters.AddWithValue("@floorsNo", floorNo);
        using(SqlDataAdapter SE_ADAPTAR = new SqlDataAdapter(com))
        {  
            SE_ADAPTAR.Fill(ds);
            conn.Close();
        }
        return ds;
    }
