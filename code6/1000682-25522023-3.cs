    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {    
             Button btnSubmit = e.Row.FindControl("btnSubmit") as Button;
             btnSubmit.Attributes.Add("OnClick", "ShowProgress();");
        }
    }
