    public void myMethod()
    {
        this.OpenConn(); //opens the connection
    
        string sql = "SELECT id FROM information_schema.tables WHERE table_schema = 'public' AND table_name = 'customers' ORDER BY id DESC, LIMIT 1";
    
        using (NpgsqlCommand command = new NpgsqlCommand(sql, conn))
        {
            int val;
            NpgsqlDataReader reader = command.ExecuteReader();
            while(reader.Read()){
               val = Int32.Parse(reader[0].ToString());
               //do whatever you like
            }
            
            this.CloseConn(); //close the current connection
        }
    }
