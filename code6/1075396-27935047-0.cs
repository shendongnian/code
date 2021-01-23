    for (int i = 0; i < dataTable.Columns.Count; i++)
    {
        bool columnFound = false;
        foreach (GRTColumnView uiColumn in descriptor.UIColumns)
        {
            if (dataTable.Columns[i].Name.Equals(uiColumn.Name))
            {
                columnFound = true;
                break;
            }
        }
        if (!columnFound)
        {
            if (this.dataTable.Columns.Contains(dataTableCol.ColumnName))
                this.dataTable.Columns.Remove(dataTableCol.ColumnName);
        }
    }
