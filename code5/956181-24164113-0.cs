     // PostgeSQL-style connection string
       string connstring = String.Format("Server={0};Port={1};" + 
                        "User Id={2};Password={3};Database={4};",
                        tbHost.Text, tbPort.Text, tbUser.Text, 
                        tbPass.Text, tbDataBaseName.Text );
                    // Making connection with Npgsql provider
       NpgsqlConnection conn = new NpgsqlConnection(connstring);
       conn.Open();
       // quite complex sql statement
       string sql = "SELECT * FROM simple_table";
       // data adapter making request from our connection
       NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
