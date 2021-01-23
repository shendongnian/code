    public Data[] GetDeptAppData()
    {
        //execute stored procedure to get data from database
        using (SqlConnection sqlConnection = new SqlConnection("Data Source=MyServer;Initial Catalog=MyCatalog;Persist Security Info=True;User ID=MyUser;Password=MyPassword"))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SP_Admin_DeptApp_Load";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            using (var reader = cmd.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    // throw exception
                }
                var lst = new List<Data>();
                while (reader.Read())
                {
                    var row = new Data();
                    row.DeptApp = reader.GetString(0);
                    row.Status = reader.GetString(1);
                    row.Supervisor = reader.GetString(2);
                    lst.Add(row);
                }
                return lst.ToArray();
            }
        }
    }
