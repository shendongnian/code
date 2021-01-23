        // Create a connection to the database        
    SqlConnection conn = new SqlConnection("Data Source=MyDBServer;Initial Catalog=MyDB;Integrated Security=True");
    // Create a command to extract the required data and assign it the connection string
    SqlCommand cmd = new SqlCommand("SELECT * FROM Product", conn);
    cmd.CommandType = CommandType.Text;
    // Create a DataAdapter to run the command and fill the DataTable
    SqlDataAdapter da = new SqlDataAdapter();
    da.SelectCommand = cmd;
    DataTable dt = new DataTable();
    da.Fill(dt);
