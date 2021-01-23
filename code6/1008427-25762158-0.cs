     myCommand2.CommandText = "SELECT fieldName FROM parameters WHERE Form_Factor = 'Mercury'";
     using (connect)
           {
             connect.Open();
             MySqlDataReader reader2 = myCommand2.ExecuteReader();
            
                while (reader2.Read())
                {
                    string command = reader2["fieldName"].ToString();
                   MessageBox.Show(command);
                }
           }
