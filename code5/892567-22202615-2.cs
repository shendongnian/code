    SqlCOnnection con=new SqlConnection("/*connection string here*/");
    string query = "SELECT [DateCol] FROM TABLENAME]";
    SqlCommand cmd=new SqlCommand(query,con);
    
    con.Open(); 
    SqlReader reader = cmd.ExecuteReader();
    while(reader.Read())
    {
       DateTime dt= Convert.ToDateTime(reader["DateCol"].ToString());
       string mydateString = dt.ToString("dd/MM/yyyy");
    }
    con.Close();
