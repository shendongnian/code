    SqlConnection sqlc= new SqlConnection("data source=. ; database=LDatabase; integrated security=true");
    SqlCommand cmd= new SqlCommand("select MAX(G_ID) as MAXID from Groups", sqlc);
    
    sqlc.Open();
    SqlDataReader Reader= cmd.ExecuteReader();
    int MaxID = 0;
    if (Reader.Read())
    {
        MaxID = Convert.ToInt32(Reader["MAXID"].ToString());
        MaxID += 1;
    }
