     private void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn comboboxColumn)
    {
        {
            comboboxColumn.DataSource = collection;
            comboboxColumn.ValueMember = ColumnName;
            comboboxColumn.DisplayMember = ValueMember;
        }
    }
