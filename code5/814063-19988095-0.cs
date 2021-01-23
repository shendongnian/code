    decimal proteinAvg;
    // MySql uses 'database' and not 'Initial Catalog' like Sql does.
    string myConnection = string myConnection = "datasource=localhost;Database=mydatabase;port=3306;username=root;password=root";  // MySql uses 'database' to define the DB name.
    string Query = "SELECT AVG(Protein) AS proteinAvg FROM nutritioncalculator";
       
    // Wrap your connection and command objects in 'using' blocks.  
    // Both implement IDisposable and will be managed by GC once 
    // they fall out-of-scope. 
    using (MySqlConnection myConn = new MySqlConnection(myConnection))
    {   
       using (MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn))
       {
          MySqlDataReader myReader;
       }
    }
    
    try
    {
       myConn.Open();
       //checkpoint1
       MessageBox.Show("connected");
       myReader = cmdDatabase.ExecuteReader();
       //Checkpoint2
    
       MessageBox.Show("connected");
       while (myReader.Read())
       {
          //checkpoint3
          MessageBox.Show("connected");
          proteinAvg = (decimal) myReader["proteinAvg"];
          MessageBox.Show("Your protein intake should be around" + proteinAvg);
       }
    }
