    protected void getdata()
    {
        property.banner_id = 0;
        property.banner_type = "Primary";
        DataSet ds = bal.getdata_view(property.banner_id, property.banner_type);
        DataTable dt = ds.Tables[0];
        ViewState["getdata_primary"] = dt;
        if (dt.Rows.Count > 0)
        {
            rptMain.DataSource = bal.getdata_view(property.banner_id, property.banner_type);
            rptMain.DataBind();
            lblmsg.Text = "";
            lblmsg.Visible = false;
            Button5.Visible = true;
        }
    }
