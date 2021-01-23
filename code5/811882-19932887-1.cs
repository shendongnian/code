    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        BindData();          
    }
     
    private void BindData()
    {
        DataSet dtSet = new DataSet();
        using (connection = new SqlConnection(connectionString))
        {
            command = new SqlCommand(sql, connection);              
            SqlDataAdapter adapter = new SqlDataAdapter();          
            connection.Open();
            adapter.SelectCommand = command;
            adapter.Fill(dtSet, "Customers");
            listBox1.DataContext = dtSet;
         
        }
    }
