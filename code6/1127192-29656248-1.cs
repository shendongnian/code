    private void LoadTable1(int id)
    {
       using (SqlConnection conn = new SqlConnection(sConnectionString)) 
       using (SqlCommand table1CMD = getSelectTable1(conn, id))
       using (SqlDataAdapter table1DA = new SqlDataAdapter (table1CMD))
       {
          table1DA.Fill(Table1);
       }
    }
