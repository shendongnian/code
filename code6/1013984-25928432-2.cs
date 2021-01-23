     public DataTable show(string query)
        {
         string strcon = @"Data Source=client-2;Initial Catalog=Name;Integrated Security=True;Pooling=False";          
        SqlDataAdapter da;
        DataTable dt;      
       SqlConnection     con = new SqlConnection(strcon);
       con.Open();
       string qry = "Select * from Dbname";
       da = new SqlDataAdapter(qry, strcon);
       dt = new DataTable();
       da.Fill(dt);                            
       return dt;
       }
