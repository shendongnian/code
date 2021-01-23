    string connection = "your connection string";
    try
    {
      using(SqlConnection conn = new SqlConnection(connection))///add your connection string
      {
        String sql="ALter Table MyTable add SomeField Decimal(18,3)";
        conn.Open();
        using( SqlCommand command = new SqlCommand(sql,conn))
        {
          command.ExecuteNonQuery();
        }
      }
    }
    catch (Ecxeption ex)
    {
     MessageBox.Show(ex.Message);
    }
 
 
        
