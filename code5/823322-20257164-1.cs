        public ArrayList GetTables()
        {
            ArrayList list = new ArrayList();
            // executes query that select names of all tables in master table of the database
                String query = "SELECT name FROM sqlite_master " +
                        "WHERE type = 'table'" +
                        "ORDER BY 1";
            try
            {
                
                DataTable table = GetDataTable(query);
                // Return all table names in the ArrayList
                foreach (DataRow row in table.Rows)
                {
                    list.Add(row.ItemArray[0].ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return list;
        }
        public DataTable GetDataTable(string sql)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var c = new SQLiteConnection(dbConnection))
                {
                    c.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, c))
                    {
                        using (SQLiteDataReader rdr = cmd.ExecuteReader())
                        {
                            dt.Load(rdr);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
