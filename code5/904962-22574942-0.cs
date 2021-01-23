        // Suppose you want to add 10 rows
        int totalRows = 10;
        int totalColumns = 5;
        for (int r = 0; r <= totalRows; r++)
        {
            TableRow tableRow = new TableRow();
            for (int c = 0; c <= totalColumns; c++)
            {
                TableCell cell = new TableCell();
                TextBox txtBox = new TextBox();
                txtBox.Text = "Row: " + r + ", Col:" + c;
                cell.Controls.Add(txtBox);
                //Add the cell to the current row.
                tableRow.Cells.Add(cell);
                    
                if (c==5)
                {
                    // This is the final column, add the row
                    table.Rows.Add(tableRow);
                }
            }
        }
