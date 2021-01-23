    protected void gv_RowDataBound(object sender, GridViewEditEventArgs e)
    {
    	if (e.Row.RowType == DataControlRowType.DataRow)
    	{
    		if ((e.Row.RowState & DataControlRowState.Edit) > 0)
    		{
    			DropDownList ddList= (DropDownList)e.Row.FindControl("DStatusEdit");
    			//bind dropdownlist
    			DataTable dt = con.GetData("select distinct status from directory");
    			ddList.DataSource = dt;
    			ddList.DataTextField = "YourCOLName";
    			ddList.DataValueField = "YourCOLName";
    			ddList.DataBind();
    
    			DataRowView dr = e.Row.DataItem as DataRowView;
    			//ddList.SelectedItem.Text = dr["YourCOLName"].ToString();
    			ddList.SelectedValue = dr["YourCOLName"].ToString();
    		}
       }
    }
