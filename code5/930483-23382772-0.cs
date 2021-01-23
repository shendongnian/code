    DataTable dt = new DataTable();
    
    using (SqlConnection con = new SqlConnection(myStr))
    {
        string sql = "select ItemCode,ItemName,PointsNeeded from tb_ItemRedemption where (ItemCode is null or ItemCode = @txtkey2) or (ItemName is null or ItemName = @txtkey2)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@txtkey2", txtkey2.Text.Trim());
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //You're currently adding a blank DataTable to a session variable below as you've not 
        //filled it yet. I've left this incase that's what you meant to do.
        Session["ItemCode"] = dt;
        con.Open();
        //SqlDataAdapter should be able to fill a DataTable as well as a dataset.
        sda.Fill(dt);
        if (dt.Rows.Count > 0) //Put a breakpoint here to check if anything is returned in dt
        {
            dt.Columns.Add("Quantity");
            dt.Columns.Add("TotalPoints");
            // for caliculation 
            txtPointsNeeded.Text = dt.Rows[0]["PointsNeeded"].ToString();
       
            //Not sure what you're trying to do here. You're just adding a blank row to dt.
            DataRow dr;
            dr = dt.NewRow();
            dt.Rows.Add(dr);
            // for caliculation 
            txtGetQuantity.Text = txtQuantity.Text;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            GridView1.Visible = true;
        }
        else
        {
            //Code to handle nothing being returned.
        }
    }
         
