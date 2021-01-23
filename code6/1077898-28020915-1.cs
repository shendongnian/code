    // see how parameters are used
    
    SqlCommand sqlcommand0;
    
    using (SqlConnection conn = new SqlConnection(con_str))
    
    {
    
        conn.Open();
        string sql = "INSERT INTO dbo.HWTable(Brand, CPU, RAM, HSerial, Model, ACode, PYear, UName, Position, Depart) VALUES(@Brand, @CPU, @RAM, @HSerial, @Model, @ACode, @PYear, @UName, @Position, @Depart)";       // (1)
    
        try                                                // (2)
    
        {
    
            using (sqlcommand0 = new SqlCommand(commandtext, conn)) // (3)
    
            {
    
                sqlcommand0.Parameters.Add(new SqlParameter("@Brand", Brand.Text));
                            
                sqlcommand0.Parameters.Add(new SqlParameter("@CPU", CPU.Text));
    
                ....
    
                sqlcommand0.ExecuteNonQuery();
        
            }
    
        }
    
        catch
    
        {
    
            Console.WriteLine("Count not insert data into table.");
    
        }
    
    }
