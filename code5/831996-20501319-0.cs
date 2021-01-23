    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
          conn.Open();
          SqlCommand comm = new SqlCommand("SELECT * FROM Accounts WHERE ID = @ID AND Open = 1", conn);
          comm.Parameters.AddWithValue("@ID", Session["ID"]);
          using(var dataReader = comm.ExecuteReader())
          {
              if(dataReader.HasRows())
               {
                    while(dataReader.Read())
                    {
                        var myRowColumn1 = dataReader["NameOfColumnInDataBase"].ToString();
                     }
               }
          }
           
