        DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
        buttonColumn.Name = "uninstall_column";
        buttonColumn.Text = "Uninstall";
        if (dataGridViewSoftware.Columns["uninstall_column"] == null)
        {
            dataGridViewSoftware.Columns.Insert(columnIndex, uninstallButtonColumn);
        }
