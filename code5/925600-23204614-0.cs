    if ( !IsPostBack)
    {    
         NpgsqlConnection conn = new NpgsqlConnection("Server=127.0.0.1;Port=5432;Database=SYS;User Id=postgres;Password=postgres;");
         conn.Open();
         NpgsqlCommand command = new NpgsqlCommand("SELECT name FROM tbl_syv ORDER BY name", conn); 
         NpgsqlDataReader dr = command.ExecuteReader();
         while (dr.Read())
         {
             ddPersons.Items.Add((string)dr["name"] + " " + " ");
         }
    }
