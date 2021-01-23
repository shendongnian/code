    using (SqlConnection connection = new SqlConnection(@"Data Source=***;Integrated Security=False;User ID=***;Password=***;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False"))
    using (SqlCommand command = new SqlCommand("Select * FROM sys.databases;"))
    {
          command.Connection = connection;//This is missing in your code.
          connection.Open();
          
          dataGridDataBase.DataSource = command.ExecuteReader();
          dataGridDataBase.DataBind();
    }
