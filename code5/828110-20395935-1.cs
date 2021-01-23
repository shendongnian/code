       List<string> excelName = new List<string>();   
       DataSet ds = new DataSet();  
       foreach(var name in excelName )
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {        
                DataTable dt = new DataTable();
                string query ="select * from '"+name+"'";
                con.Open();
                SqlDataAdapter da = new OleDbDataAdapter(query, con);
                da.Fill(dt);
                con.Close();    
                ds.add(dt);            
            }
        }
        gridview.DataSource = ds;
        gridview.DataBind();
