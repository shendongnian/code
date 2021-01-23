     using (SQLiteConnection connection = 
            new SQLiteConnection("Data Source=" + openFileDialog.FileName + ";Version=3;"))
        {
           connection.Open();
           string selectMaxId = "Select Max(PolygonId) From Polygons";
        
           SQLiteCommand selectMaxCmd = new SQLiteCommand(selectMaxId,connection);
        
           
           int maxId = -1;
           using (SqliteDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read()) 
                        {
                            maxId = dataReader.GetInt32(1));
                        }         
                    }
        }
