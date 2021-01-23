        // your db name
        static string dbName = "myDbName";
        // path to your db files:
        // ensure that the directory exists and you have read write permission.
        string[] files = { Path.Combine(Application.StartupPath, dbName + ".mdf"), 
                   Path.Combine(Application.StartupPath, dbName + ".ldf") };
    public bool CreateDatabase()
        {
            bool stat = true;
            string sqlCreateDBQuery;
            SqlConnection myConn = new SqlConnection("Server=(localdb)\\v11.0;Integrated Security=true;");
            
            var query = "CREATE DATABASE " + dbName +
                " ON PRIMARY" +
                " (NAME = " + dbName + "_data," +
                " FILENAME = '" + files[0] + "'," +
                " SIZE = 10MB," +
                " MAXSIZE = 100MB," +
                " FILEGROWTH = 10%)" +
                " LOG ON" +
                " (NAME = " + dbName + "_log," +
                " FILENAME = '" + files[1] + "'," +
                " SIZE = 1MB," +
                " MAXSIZE = 5MB," +
                " FILEGROWTH = 10%)" +
                ";";
            SqlCommand myCommand = new SqlCommand(query, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e.ToString());
                stat =  false;
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
                myConn.Dispose();
            }
            return stat;
        }
