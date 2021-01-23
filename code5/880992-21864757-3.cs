    List<string> wordList = new List<string>();
    string connection = "YourConnectionString";
    OleDbConnection con = new OleDbConnection(connection);
    string query = "SELECT * FROM yourTable WHERE ID=@param"; // add as many conditions as you need
    OleDbCommand comm = new OleDbCommand(query, con);
    comm.Parameters.AddWithValue("@param", textBox1.Text); //example of parameter
    con.Open();
    OleDbDataReader rdr = comm.ExecuteReader();
                    
    while (rdr.Read()) //this will loop through all rows with given conditions.
    {
         wordList.Add(rdr.GetString(rdr.GetOrdinal("YourSQLColumn")).Trim());
    }
    con.Close();
    Random rnd = new Random();
    int randomint = rnd.Next(1, 20); // generates a random number between 1 and 20
    label1.Text = wordList[randomint].ToString();
