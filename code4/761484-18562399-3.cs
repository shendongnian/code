    string connectionString =
        "Data Source=192.168.123.45;Initial Catalog=MyDatabase;Integrated Security=SSPI;";
    using (SqlConnection connection = new SqlConnection(connectionString)) {
        using (SqlCommand command = new SqlCommand(
                     "SELECT Region FROM dbo.tlkpRegion WHERE RegionID=30", connection)) {
            connection.Open();
            string result = (string)command.ExecuteScalar();
            MessageBox.Show("Region = " + result);
        }
    }
