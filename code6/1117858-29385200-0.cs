    protected override void Render(HtmlTextWriter writer)
    {
        string lastSubCategory = String.Empty;
        Table gridTable = (Table)gvProducts.Controls[0];
        foreach (GridViewRow gvr in gvProducts.Rows)
        {
            HiddenField hfSubCategory = gvr.FindControl("hfSubCategory") as
                                        HiddenField;
            string currSubCategory = hfSubCategory.Value;
            if (lastSubCategory.CompareTo(currSubCategory) != 0)
            {
                int rowIndex = gridTable.Rows.GetRowIndex(gvr);
                // Add new group header row
                GridViewRow headerRow = new GridViewRow(rowIndex, rowIndex,
                    DataControlRowType.DataRow, DataControlRowState.Normal);
                TableCell headerCell = new TableCell();
                headerCell.ColumnSpan = gvProducts.Columns.Count;
                headerCell.Text = string.Format("{0}:{1}", "SubCategory",
                                                currSubCategory);
                headerCell.CssClass = "GroupHeaderRowStyle";
                // Add header Cell to header Row, and header Row to gridTable
                headerRow.Cells.Add(headerCell);
                gridTable.Controls.AddAt(rowIndex, headerRow);
                // Update lastValue
                lastSubCategory = currSubCategory;
            }
        }
        base.Render(writer);
    }
