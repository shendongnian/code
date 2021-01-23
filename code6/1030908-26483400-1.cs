    foreach (DataGridViewRow row in RGV.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                row.Cells["Status"].Value = "Check";
                if (RGV.SelectedColumns.Contains(cell.OwningColumn))
                { 
                    row.Cells["Status"].Value = "OK";
                    break; 
                }
            }
        }      
