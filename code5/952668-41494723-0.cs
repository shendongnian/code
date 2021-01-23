     using (var command = new NpgsqlCommand(sql, conn))
     {
            int id = 0; 
            var reader = command.ExecuteReader();
            while(reader.Read())
            { 
               var id = Int32.Parse(reader["id"].ToString());
            }
            this.CloseConn(); 
     }
