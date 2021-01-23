        public void CreateTables()
        {
            SqlConnection conn1 = new SqlConnection();
            try
            {
                
                // Drop and Create a new Patient Table
                string queryDrop = "IF OBJECT_ID('Patient', 'U') IS NOT NULL DROP TABLE Patient";
                conn1.ConnectionString = GetConnectionString();
                conn1.Open();
                SqlCommand cmdDrp = new SqlCommand(queryDrop, conn1);
                cmdDrp.ExecuteNonQuery();
                string query = "CREATE TABLE Patient(" +
                          "PatientId uniqueidentifier DEFAULT NEWSEQUENTIALID()," +
                          "PatientName varchar(50) NOT NULL," +
                          "Gender varchar(50) NOT NULL," +
                       ")";
                SqlCommand cmd1 = new SqlCommand(query, conn1);
                cmd1.ExecuteNonQuery()
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn1.Close();//close the connection
            }
     }
        public string GetConnectionString()
        {
            string folderpath = Environment.GetFolderPath
            (Environment.SpecialFolder.Personal);      
            string connStr = "Data Source=.\\SQLEXPRESS;AttachDbFilename=" + folderpath
            + "\\FolderName\\Hospitaldata.mdf;Integrated Security=True;" +
            "Connect Timeout=30;User Instance=True";
          
            return connStr;
        }
