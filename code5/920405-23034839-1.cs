    using (MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection("S;Port=P;Database=DB;Uid=U;Pwd=P"))                      {
           connection.Open();
           MySql.Data.MySqlClient.MySqlCommand cmd=connection.CreateCommand();
           cmd.CommandText = "SELECT * FROM table_name";
           MySql.Data.MySqlClient.MySqlDataReader datr = cmd.ExecuteReader();            
           coun = Convert.ToInt32(cmd.ExecuteScalar());
           int counter = 0;
           string[] First_String = new string[datr.FieldCount];
           string[] Second_String = new string[datr.FieldCount];
           string[] Third_String = new string[datr.FieldCount];
           while (datr.Read()){                          
                     First_String[counter] = datr[0].ToString();
                     Second_String[counter] = datr[1].ToString();
                    Third_String[counter] = datr[2].ToString();
                            /* and so on...*/   
                    counter++;
           }
    }
