     public void loadChart(string schema)
     {
       try
       {   
         string allTables =
               " SELECT table_name, count(COLUMN_NAME) " 
             + " FROM information_schema.COLUMNS " 
             + " where table_schema = '" + schema + "' group by table_name" ;
         MySqlCommand cmd = new MySqlCommand(allTables, DBC);
         MySqlDataReader rdr = cmd.ExecuteReader();
         ch_tables.Series["columns"].Points.Clear();
         while (rdr.Read()) 
         {
             ch_tables.Series["columns"].Points.AddXY(rdr[0], rdr[1]);
         }
         rdr.Close();
       } 
       catch (MySqlException ex)  { /* error handling */ }
     }
