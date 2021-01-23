	DataGridRow firstRow = null;
    DataGridRow lastRow = null;
    for (int i = 0; i < dataGrid.Items.Count; i++)
    {
        DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i);
        if (row != null)
        {
            firstRow = row;
            while (row != null)
            {
                row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(++i);
            }
            lastRow = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(i - 1);
            break;
        }
    }
