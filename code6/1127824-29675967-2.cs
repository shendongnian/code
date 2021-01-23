    using (MySqlDataReader reader = cmd.ExecuteReader())    
    {
    
    int retrievedValue = 0;
    
          while (reader.Read())
          {
                if (reader.Read() == 0)
                {
                    
                    GridView View2 = sender as GridView;
                                    e.Appearance.BackColor = Color.Green;
                                    e.Appearance.BackColor2 = Color.ForestGreen;
                }
          }
          reader.Close();
    }
