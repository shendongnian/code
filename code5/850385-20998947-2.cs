    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
         e.Row.Attributes.Add("OnClientClick", "return setVisible('cfilterpopup');");
    }
