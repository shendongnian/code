    public void FillGrid()
    {
    //here your grid view binding code
    }
    
    public void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    grdData.PageIndex=e.NewPageIndex;
    FillGrid();
     }
