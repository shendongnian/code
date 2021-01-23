        private void SelectAllItems()
        {
            foreach (DataGridViewRow row in itemsBySupplier.Rows)
            {
                // This will check the cell.
                row.Cells["selectItem"].Value = "true";
            }
        }
    foreach (DataGridViewRow row in itemsBySupplier.Rows)
    {
        string hid = row.Cells["Hid"].Value.ToString();
        if (Ws.ToCreate[_supplier].Count(i => i.Hid == hid) > 0)
        {
            row.Cells["selectItem"].Value = "true";                        
        }
    }
