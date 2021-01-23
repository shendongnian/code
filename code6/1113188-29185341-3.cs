    string command = "......";  // your SQL query, as before
    
    using (SqlConnection con = new SqlConnection("Data Source=MyDB;Initial Catalog=Graphic;Integrated Security=True"))
    {
        con.Open();
        IEnumerable<DTO> results = con.Query<DTO>(command);
        con.Close();
    }
