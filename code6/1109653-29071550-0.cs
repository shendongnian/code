    protected void gvItemList_RowDataBound(object sender, GridViewEditEventArgs e)
        {
         if (e.Row.RowType == DataControlRowType.DataRow)
          {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                  DropDownList ddList= (DropDownList)e.Row.FindControl("ddlItem");
                  //bind dropdownlist
                  DataTable dt = con.GetData("select * from tablename");//selected data from db or  anywhere for bind ddl
                  ddList.DataSource = dt;
                  ddList.DataTextField = "YourCOLName";//id
                  ddList.DataValueField = "YourCOLName";//displaying name
                  ddList.DataBind();
    
                  DataRowView dr = e.Row.DataItem as DataRowView;                 
                  ddList.SelectedValue = dr["YourCOLName"].ToString();// default selected value
                }
           }
        }
