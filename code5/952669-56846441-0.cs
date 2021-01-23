    public void myMethod()
    {
        this.OpenConn(); //opens the connection
    
        string sql = "SELECT id FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'customers' ORDER BY id DESC, LIMIT 1";
    
        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
         {
           int id= (int)DBHelperRepository.ExecuteScalarSync(sqlString, CommandType.Text);
    
           this.CloseConn(); //close the current connection
         }
    }
