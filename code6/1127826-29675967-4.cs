     using (MySqlDataReader reader = cmd.ExecuteReader())    
        {
        
        int retrievedValue = 0;
        
              while (reader.Read())
              {
                    retrievedValue = (int)reader.GetValue(0);
                    if (retrievedValue == 0)
                    {
                        
                        GridView View2 = sender as GridView;
                                        e.Appearance.BackColor = Color.Green;
                                        e.Appearance.BackColor2 = Color.ForestGreen;
                    }
                    else if (retrievedValue == 1)
                    {
                        
                        GridView View2 = sender as GridView;
                                        e.Appearance.BackColor = Color.Red;
                                        e.Appearance.BackColor2 = Color.ForestGreen;
                    }
              }//and so on...
              reader.Close();
        }
    
    
