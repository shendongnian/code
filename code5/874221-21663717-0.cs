        public SqlDataReader GetData() 
        {
            SqlDataReader sqlReads = null;
            SqlCommand sqlCommand = new SqlCommand("select * from table_name", GetConnection());
            connection.Open();
            sqlReads = sqlCommand.ExecuteReader();
            return sqlReads;
        }
