    protected void grdInnerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Control outerRow = e.Row.Parent.NamingContainer;
            while(!(outerRow is IDataItemContainer))
            {
                outerRow = outerRow.NamingContainer; 
            }
            string cID = ((OuterDataType)((IDataItemContainer)outerRow)).nitter;
            int iID = ((InnerDataType)e.DataItem).Id;
            GridView innerGridView2 = (GridView)e.Row.FindControl("grdInnerGridView2");
            FillInnerGrid2(cID, iID, innerGridView2);
        }
    }
