        foreach (GridViewColumnHeader column in _gridView.Columns)
        {
            if (column.Width == 0)
                continue;
            ComboBoxItem item = new ComboBoxItem();
            item.Content=column.Header;
            string property = ((System.Windows.Data.Binding)column.DisplayMemberBinding).Path.Path;
            item.Tag= property;
            cmbSearch.Items.Add(item);
    
            cmbSearch.Items.Add(column.Header);
        }
