       List<string> excelName = new List<string>();   
       dataset ds = new dataset();  
     foreach(var namein excelName )
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {        
                datatable dt = new DataTable();
                string query ="select * from '"+name+"');
                con.open();
                SqlDataadapter da = new OleDbDataAdapter(query, con);
                da.Fill(dt);
                con.Close();    
                ds.add(dt);            
            }
        }
        gridview.datasource = ds;
        gridview.databind();
