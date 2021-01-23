    // You sql command
    MySqlCommand selectData;
    // Create the sql command
    selectData = dbcon.CreateCommand();
    // Declare the sript of sql command
    selectData.CommandText = "SELECT user_name, amount, FROM user_table";
    // Declare a reader, through which we will read the data.
    MySqlDataReader rdr = selectData.ExecuteReader();
    // Read the data
    while(rdr.Read())
    {
        string userName = (string)rdr["user_name"];
        string amount = (string)rdr["amount"];
        
        // Print the data.
        Console.WriteLine(username+" "+amount);
    }
    rdr.Close();
