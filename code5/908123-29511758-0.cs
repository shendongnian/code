    using (var cnn = new SQLiteConnection(connStr))
                {
                    //connStr = "FullUri=file::memory:?cache=shared;Pooling=True;Max Pool Size=200;";
    
                    
                    cnn.Open();
                    //cnn.EnableExtensions(true);
    
                    using (SQLiteCommand mycommand = new SQLiteCommand("SELECT load_extension(\"mod_spatialite\")", cnn))
                    {
                        mycommand.ExecuteNonQuery();
                    }
