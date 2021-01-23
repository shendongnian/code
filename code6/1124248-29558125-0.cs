    private int GetIDNum()
    {
        SqlConnection connection = new SqlConnection("connectionstring");
        using(SqlCommand command = new SqlCommand("SELECT MAX(nr2) FROM TABLE WHERE nr1 = '10'", connection))
        {
            try
            {
                connection.Open();
            
                object result = command.ExecuteScalar();
                
                if( result != null && result != DBNull.Value )
                {
                    return Convert.ToInt32( result );
                }
                else
                {
                    return 0;
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
 
