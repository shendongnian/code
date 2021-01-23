    private void InsertDEL_Stores(MyItem itm)
    {
        String strConnString = ConfigurationManager.ConnectionStrings["CBConnectionString"].ConnectionString;
        using(SqlConnection con = new SqlConnection(strConnString))
        using(SqlCommand cmd = new SqlCommand("sp_DEL_Stores_IU", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DealerCode", itm.DealerCode);
            cmd.Parameters.AddWithValue("@Code", itm.ItemCode);
            cmd.Parameters.AddWithValue("@Qty", itm.Quantity);
            cmd.Parameters.AddWithValue("@ExpireDate", itm.ExpireDate);
            cmd.Parameters.AddWithValue("@BatchNumber", itm.BatchNumber);
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
