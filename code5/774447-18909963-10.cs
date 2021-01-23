    SqlConnection connection = new SqlConnection(ConnectionString);
    command = new SqlCommand("TestProcedure", connection);
    command.CommandType = System.Data.CommandType.StoredProcedure;
    connection.Open();
    SqlDataReader reader = command.ExecuteReader();
    List<Test> TestList = new List<Test>();
    Test test = null;
    while (reader.Read())
    {
        test = new Test();
        test.ID = int.Parse(reader["ID"].ToString());
        test.Name = reader["Name"].ToString();
        TestList.Add(test);
    }
    gvGrid.DataSource = TestList;
    gvGrid.DataBind();
