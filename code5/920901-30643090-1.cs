     public void fillAlbum()
        {
            SqlConnection myconnection = new SqlConnection("Data Source=.;Initial Catalog=person;Integrated Security=True");
            SqlDataAdapter myadapter = new SqlDataAdapter("Select CatID,Title  from Category", myconnection);
            DataTable dt = new DataTable();
            myadapter.Fill(dt);
            rpt.DataSource = dt;
            rpt.DataBind();
         
    
        
        }
