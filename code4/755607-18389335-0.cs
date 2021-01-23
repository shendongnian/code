    protected void ddlTheater_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adp = new SqlDataAdapter("select showtime from assgnmovie where mvname='"+ddlMov.SelectedItem.Value+"' and thname='"+ddlTheater.SelectedItem.Value+"'",con);
        String a = adp.ToString();
        String b = a.Substring(1, 6);
        ddlShow.Text = b;
        adp.Fill(ds);
    	
    	ddlTheater.DataSource = ds;
        ddlTheater.DataValueField = "showtime";
        ddlTheater.DataBind();
     }
