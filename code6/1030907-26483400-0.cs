    foreach (DataGridViewRow row in RGV.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Here you test every cell in row, if its column is actually selected
                    if (RGV.SelectedColumns.Contains(cell.OwningColumn))
                    {
                        //work here with the cell
                    }
                }
            }
