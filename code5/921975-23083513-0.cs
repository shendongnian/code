    public static void Delete(int ID)
    {
    using (SqlConnection conn = new SqlConnection())
    {
            conn.connectionString = "";
    conn.open();   	
    sqlcommand sc = new sqlcommand();
            sc.connection = conn;
            
            sc.commandText = "DELETE FROM TABLE WHERE ID = @ID";
            
            sc.Parameters.AddWithValue("@ID", ID);
            
            
            sc.ExecuteNonQuery();
    		
            conn.close()
    }
    }
