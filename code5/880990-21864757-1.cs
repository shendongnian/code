     List<string> wordList = new List<string>();
    string connection = "Data Source=YourServer;Initial Catalog=YourDatabase;User=YourUN;pass=YourPass";
    SqlConnection con = new SqlConnection(connection);
    string query = "SELECT * FROM yourTable WHERE ID=@param";
    SqlCommand comm = new SqlCommand(query, con);
    comm.Parameters.AddWithValue("@param", textBox1.Text); //example of parameter
    con.Open();
    SqlDataReader rdr= comm.ExecuteReader();
                    
    while (rdr.Read())
    {
    wordList.Items.Add(rdr.GetString(rdr.GetOrdinal("YourSQLColumn")).Trim());
    }
    con.Close();
    Random rnd = new Random();
    int randomint = rnd.Next(1, 20);
    label1.Text = wordList[randomint].ToString();
