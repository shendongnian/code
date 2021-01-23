    using System.Data;  
    using System.Data.Client;  
    
    SqlConnection con = new SqlConnection("your connection string here");  
    con.Open();  
    SqlCommand cmd = new SqlCommand("sp_CreateTable");  
    cmd.CommandType = CommandType.StoredProcedure;  
    cmd.Parameters.Add("@TableName", SqlDbType.VarChar).Value = "someName";  
    cmd.Parameters.Add("@ColumnName", SqlDbType.VarChar).Value = "someColumnName";  
    cmd.ExecuteNonQuery();  
    con.Close();
  
