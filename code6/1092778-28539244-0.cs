    public static DataGridCell GetCell(DataGrid dataGrid, int row, int column)
    {
        DataGridRow rowContainer = GetRow(dataGrid, row);
        if (rowContainer != null)
        {
            DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(rowContainer);
            // try to get the cell but it may possibly be virtualized
            DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
            if (cell == null)
            {
                // now try to bring into view and retreive the cell
                dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
            }
            return cell;
        }
        return null;
     }
