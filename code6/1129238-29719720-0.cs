    private void button1_Click(object sender, EventArgs e)
    {
        string connectionString = ConfigurationManager.ConnectionStrings["myconnectionstring"].ConnectionString;
        using(var connect = new SqlConnection(connectionString))
        using(var command1 = connect.CreateCommand())
        {
             command1.CommandText = "INSERT INTO Questions ([Question Type]) VALUES (1)";
             connect.Open();
             command1.ExecuteNonQuery();
        }
    }
