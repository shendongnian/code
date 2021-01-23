    protected void Page_PreInit(object sender, EventArgs e)
    {
        // whatever other code you have up here
        HtmlTableCell tCellJson= new HtmlTableCell();
        HiddenField hdnJson = new HiddenField();
        hdnJson.ID = "hdnJson"+ count;
    
        tCellJson.Controls.Add(hdnJson);
        tRow.Cells.Add(tCellJson);
    }
