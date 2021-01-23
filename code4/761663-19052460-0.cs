            string connectionString;
            string fileName = "test.sdf";
            string password = "test";
             if (File.Exists(fileName))
                File.Delete(fileName);
            
            connectionString = string.Format("DataSource=\"{0}\"; Password='{1}'", fileName, password);
            SqlCeConnection conn = null;
            try {
                SqlCeEngine engine = new SqlCeEngine(connectionString);
                engine.CreateDatabase();
                conn = new SqlCeConnection(connectionString);
                conn.Open();
                SqlCeCommand cmd = conn.CreateCommand();
                cmd.CommandText = "CREATE TABLE myTable (col1 int, col2 ntext)";
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
            finally {
                conn.Close();
            }
