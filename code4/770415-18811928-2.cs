    private DataTable LoadGrid()
    {
          DataTable dt = new DataTable();
          sqlcmd = new SqlCommand("selectActiveLogs", sqlcon);
          sqlcmd.CommandType = CommandType.StoredProcedure;
          try
           {
                sqlcon.Open();
                da = new SqlDataAdapter(sqlcmd);
                dt.Clear();
                da.Fill(dt);
                return dt;
           }
          catch (Exception ex)
           {}
    }
