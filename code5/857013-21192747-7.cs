    DataGridViewButtonColumn uninstallButtonColumn = new DataGridViewButtonColumn();
    uninstallButtonColumn.Name = "uninstall_column";
    uninstallButtonColumn.Text = "Uninstall";
    int columnIndex = 2;
    if (dataGridViewSoftware.Columns["uninstall_column"] == null)
    {
        dataGridViewSoftware.Columns.Insert(columnIndex, uninstallButtonColumn);
    }
