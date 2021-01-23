    string connectionString = "< your connection string >";
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
        connection.Open();
        OleDbCommand command = new OleDbCommand();
        command.Connection = connection;
        command.CommandText = "SELECT LOCATION, LINK, TAGS FROM [dbo].[NewsTable]";
        command.CommandType = CommandType.Text;
        using (OleDbDataReader reader = command.ExecuteReader())
        {
            menu_ul_1.DataSource = reader;
            menu_ul_1.DataBind();
        }
    }
