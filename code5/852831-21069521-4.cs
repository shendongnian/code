     private DataTable Get()
        {
           DataTable dt = new DataTable();
           using(SqlConnection conn = new SqlConnection(yourConnString) )
           {
             string qry = "Select * From YourTable";
             using(SqlCommand command = new SqlCommand(qry,conn))
             {
               conn.Open();
               command.CommandType= CommandType.Text;
              using(var reader = command.ExecuteReader(CommandBehaviour.CloseConnection))
             {
                dt.Load(reader);
             }
               
               con.Close();
             }
            
        
           }
          return dt;
        }
