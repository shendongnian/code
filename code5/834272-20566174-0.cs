    using(SqlConnection conn1 = new SqlConnection("Data Source=ZAZIKHAN\\SQLEXPRESS;Initial Catalog=resume;Integrated Security=True"))
    {
      //Write here your command with parameterized way..
      conn1.Open();
      if (cmd3.ExecuteNonQuery() == 1)
      {
        //....
      }
    }
