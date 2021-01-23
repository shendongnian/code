    myCommand2.CommandText = "SELECT @gb FROM parameters WHERE Form_Factor =@ff ";
    myCommand2.Parameters.AddWithValue("@gb", gb);
    myCommand2.Parameters.AddWithValue("@ff", ff);
         using (connect)
               {
                 connect.Open();
                 MySqlDataReader reader2 = myCommand2.ExecuteReader();
                
                    while (reader2.Read())
                    {
                        string command = reader2[0].ToString();
                       MessageBox.Show(command);
                    }
               }
