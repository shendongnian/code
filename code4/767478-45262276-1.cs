            string _mdfCommand = "select physical_name from sys.database_files where type = 0";
            string _ldfCommand = "select physical_name from sys.database_files where type = 1";
 
            SqlCommand GetSQLData = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            GetSQLData.CommandText = _mdfCommand;
            GetSQLData.Connection = connection;
            string mdf_Path= (string)GetSQLData.ExecuteScalar();
            GetSQLData.CommandText = _ldfCommand;
            GetSQLData.Connection = connection;
            string ldf_Path= (string)GetSQLData.ExecuteScalar();
            connection.Close();
