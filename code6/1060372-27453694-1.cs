    private void printDocument1_PrintPage(object sender, 
                                          System.Drawing.Printing.PrintPageEventArgs e)
    {
        // a short reference to the DataGridView we want to print
        DataGridView DGV = yourDataGridView;
        // I prefer mm, pick your own unit!
        e.Graphics.PageUnit = GraphicsUnit.Millimeter;
        // I want to print the columns at these fixed positions
        // the first one is the left margin, 
        // the last one a dummy at the right page margin
        int[] tabStops = new int[4] {15, 30, 100, 200};
        // I want only one column to be right-aligned:
        List<int> rightAlignedCols = new List<int>() { 1 };
        // we need to keep track of the horizontal position
        // this also the top margin:
        float y = 100;
        // we add a little space between the lines:
        float leading = 1.5f;
        // we will need to measure the texts we print:
        SizeF size = Size.Empty;
        // we use only one font:
        using (Font font = new Font("Consolas", 13f))
        {
            // I loop over the last 30 rows:
            for (int row = DGV.Rows.Count - 30; row < DGV.Rows.Count; row++)
            {
                // I print a light gray bar over every second line:
                if (row % 2 == 0) 
                    e.Graphics.FillRectangle(Brushes.Gainsboro, 
                    tabStops[0], y - leading / 2, e.PageBounds.Width - 25, size.Height);
                // I print all (3) columns in black, unless they're empty:
                for (int col = 0; col < DGV.ColumnCount; col++)
                    if (DGV[0, row].Value != null)
                    {
                        string text = DGV[col, row].FormattedValue.ToString();
                        size = e.Graphics.MeasureString(text, font, 9999);
                        float x = tabStops[col];
                        if (rightAlignedCols.Contains(col) ) 
                            x = tabStops[col + 1] - size.Width;
                        // finally we print an item:
                        e.Graphics.DrawString(text, font, Brushes.Black, x, y);
                    }
               // advance to next line:
                y += size.Height + leading;
            }
        }
    }
    private void cb_printPreview_Click(object sender, EventArgs e)
    {
        PrintPreviewDialog PPVdlg = new PrintPreviewDialog();
        PPVdlg.Document = printDocument1;
        PPVdlg.ShowDialog();
    }
