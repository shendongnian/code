    SqlDataAdapter adapter = new SqlDataAdapter();
    SqlCommand command = new SqlCommand("SELECT * FROM Orders");
    string connString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";
    SqlConnection conn = new SqlConnection(connString);
    
    adapter.SelectCommand = command;
    adapter.SelectCommand.Connection = conn;
    adapter.Fill(context.Orders);
