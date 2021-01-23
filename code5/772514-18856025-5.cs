        foreach (GridViewRow gridViewRow in gvResults.Rows)
        {
            gridViewRow.ForeColor = Color.Black;
            foreach (TableCell gridViewRowTableCell in gridViewRow.Cells)
                gridViewRowTableCell.Style["forecolor"] = "#000000";
            if (gridViewRow.RowType == DataControlRowType.DataRow)
            {
                for (int columnIndex = 0; columnIndex < gridViewRow.Cells.Count; columnIndex++)
                {
                    gridViewRow.Cells[columnIndex].Text = gridViewRow.Cells[columnIndex].Text.StripTags();
                }
            }
        }
