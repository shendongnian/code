     Try this:
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
          if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes["onclick"] =
            `enter code here`         this.Page.ClientScript.
               GetPostBackClientHyperlink((Control)sender, "Select$" + e.Row.RowIndex);
        }
     protected void gridInterventions_SelectedIndexChanging(object sender,      GridViewSelectEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
          int ID = Convert.ToInt32(row .Cells[0].Text);
         //Send your id here 
         //You can use session to save the id on one page and read in the target page
           Session["id"]=id; 
                   } 
