    // Prepare the command
    string connStr = ...
    string Query = "select sum(Page_Printed) from printjobdetails where User_ID = 'MyProperty' GROUP by User_ID";
    using(MySqlConnection conDataBase = new MySqlConnection(connStr))
    using(MySqlCommand cmdDataBase = new MySqlCommand(Query, conDataBase))
    {
        // Execute the command and get the result
        var sum = (int)cmdDataBase.ExecuteScalar();
        // Display the result
        MessageBox.Show(string.Format("Sum: {0}", sum));
    }
