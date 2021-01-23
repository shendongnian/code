    SqlConnection Connection = null;
    SqlCommand Command = null;
    string ConnectionString = ConfigurationManager.ConnectionStrings["DB_testeConnectionString"].ConnectionString;
    string CommandText = "SELECT rotina "
                       + "FROM rotinas_comercial "
                       + "WHERE nome = @someValue";
    Connection = new SqlConnection(ConnectionString);
    
    Connection.Open();
    Command = new SqlCommand(CommandText, Connection);
    Command.Parameters.Add(new SqlParameter("@someValue", DropDownList1.SelectedItem.Text));
    var results = Command.ExecuteScalar();
    Command.Dispose();
    Connection.Close();
