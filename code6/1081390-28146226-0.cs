    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ddlBloodGroup.SelectedValue != "Any")
        {
            bg = " And BloodGroup='" + ddlBloodGroup.SelectedValue + "'";
        }
        if (ddlRh.SelectedValue != "Any")
        {
            rh = " And Rh='" + ddlRh.SelectedValue + "'";
        }
        q = "select * from Donor Where 1=1 "+bg+rh;
        SqlDataSource1.SelectCommand = q;
        SqlDataSource1.DataBind();
        GridView1.DataBind();
    }
