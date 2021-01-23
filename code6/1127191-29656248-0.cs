    private void FillWithData(int id)
    {
        LoadTable1(id);
    }
    private void LoadTable1(int id)
    {
       using (SqlConnection conn = new SqlConnection(sConnectionString)) 
       using (SqlDataAdapter table1DA = new SqlDataAdapter ())
       using (SqlCommand table1CMD = getSelectTable1(conn, id))
       {
          DataTable tblTable1 = Table1;
          table1DA.SelectCommand = table1CMD;
          table1DA.Fill(tblTable1);
       }
    }
