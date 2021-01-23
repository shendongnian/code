    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HtmlGenericControl myDiv;
        LinkButton myLinkButton;
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            myDiv = (HtmlGenericControl)e.Row.FindControl("myDiv") 
                as HtmlGenericControl;
            myDiv.Visible = false;
    
            myLinkButton = (LinkButton )e.Row.FindControl("myLinkButton") 
                as LinkButton;
            myLinkButton.Visible = false;
        }
    }
