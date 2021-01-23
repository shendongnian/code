            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Width = 90;
            col.HeaderText = "Sync To Vend?"; //Header cell text
            col.Name = "SyncVendBox"; //This is the important part
            ProductGrid.Columns.Insert(2, col);
