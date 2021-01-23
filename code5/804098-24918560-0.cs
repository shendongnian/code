    public void btnSearch_Clicked(object sender, EventArgs e)
    {
        try
        {
            this.RadGrid1.Rebind();
            this.RadGrid1.CurrentPageIndex = 0;
            ViewState["newset"] = "new";
        }
        catch (Exception ex)
        {
            string errMessage = ex.Source.ToString();
        }
    }  
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (ViewState["newset"] == null) return;
        if (Session["gridTrips"] != null)
        {
            DataTable dt = (DataTable)Session["griTrips"];
            if (dt.Rows.Count > 0)
            {
                this.RadGrid1.DataSource = dt;
                this.RadGrid1.VirtualItemCount = dt.Rows.Count;
            }
        }
    }
