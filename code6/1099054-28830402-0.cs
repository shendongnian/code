    ArrayList mergedAreas = new ArrayList();
    mergedAreas = ws.Cells.MergedCells;
    
    AutoFitterOptions options = new AutoFitterOptions();
    options.AutoFitMergedCells = true;
    foreach (CellArea ca in mergedAreas)
    {
        if ((ca.EndColumn - ca.StartColumn > 0) && (ca.EndRow - ca.StartRow > 0))
        {
            ws.Cells.UnMerge(ca.StartRow, ca.StartColumn, ca.EndRow - ca.StartRow, ca.EndColumn - ca.StartColumn);
            ws.Cells.Merge(ca.StartRow, ca.StartColumn, 1, ca.EndColumn - ca.StartColumn + 1);
            ws.AutoFitRow(ca.StartRow, ca.StartColumn, ca.StartColumn, options);
            double rowHeight = ws.Cells.Rows[ca.StartRow].Height;
            for (int i = ca.StartRow; i <= ca.EndRow; i++)
            {
                ws.Cells.Rows[i].Height = rowHeight / (ca.EndRow - ca.StartRow + 1);
            }
            ws.Cells.Merge(ca.StartRow, ca.StartColumn, ca.EndRow - ca.StartRow + 1, ca.EndColumn - ca.StartColumn + 1);
        }
    }
