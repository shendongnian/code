    string customer = ComboBox.Text;
    string connectionString =
    ConsoleApplication1.Properties.Settings.Default.ConnectionString;
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    connection.Open();
    using (SqlCommand command = new SqlCommand(
    "SELECT * FROM table WHERE table.customer LIKE @Name", connection))
    {
    //
    // Add new SqlParameter to the command.
    //
    command.Parameters.Add(new SqlParameter("Name", customer));
