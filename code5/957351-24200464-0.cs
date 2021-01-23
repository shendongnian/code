    try
    {
      using(SqlConnection conn = new SqlConnection(connection))///add your connection string
      {
        String sql="ALter MyTable add SomeField Decimal(18,3)";
        conn.Open();
        using( SqlCommand command = new SqlCommand(sql,conn))
        {
          command.ExecuteNonQuery();
        }
     }
    catch (Ecxeption ex)
    {
     MessageBox.Show(ex.Message);
    }
 
 
        
