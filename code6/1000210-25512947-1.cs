    public bool IsEditable
    {
        get
        {
            if (ViewState["IsEdit"] == null)
                return false;
            else
                return (bool)ViewState["IsEdit"];
        }
        set
        {
            ViewState["IsEdit"] = value;
        }
    }
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("ID", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Rows.Add(1, "Name1");
        dt.Rows.Add(2, "Name2");
        dt.Rows.Add(3, "Name3");
        RadGrid1.DataSource = dt;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        IsEditable = true;
        RadGrid1.Rebind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            Response.Write((item.FindControl("txtName") as TextBox).Text);
            //perform your DB update here
        }
    
    
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        IsEditable = false;
        RadGrid1.Rebind();
    
    
    }
    
    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
    
            Label lblName = item.FindControl("lblName") as Label;
            TextBox txtName = item.FindControl("txtName") as TextBox;
            lblName.Visible = !IsEditable;
            txtName.Visible = IsEditable;
    
        }
    }
