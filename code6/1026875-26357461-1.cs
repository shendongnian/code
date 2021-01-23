    protected void lnkView_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string firstColData  = grdrow.Cells[0].Text;
        string secondColData  =   grdrow.Cells[1].Text;
        string thirdColData  = grdrow.Cells[2].Text;
        if (firstColData == "Somethin")
        { 
             Response.Redirect("page1.aspx");
        }
        else {
             Response.Redirect("page2.aspx");
        }
    }
