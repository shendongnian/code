    private void LoadOption()
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = new SqlConnection(@"connectionString"))
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT Site_ID FROM tbl_Survey1", con);
            adpt.Fill(dt);
            ddlSiteID.DataSource = dt;
            ddlSiteID.DataTextField = "Site_ID";
            ddlSiteID.DataValueField = "Site_ID";
            ddlSiteID.DataBind();
            ddlSiteID.Items.Insert(0, new ListItem("--Select ID--", ""));
        }
    }
