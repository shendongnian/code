    private void dgShowData_SelectionChanged(object sender, SelectionChangedEventArgs e)
     {
        DataGridRow row = GetSelectedRow(dgShowData);
        int index = dgShowData.CurrentCell.Column.DisplayIndex;
        DataGridCell columnCell = GetCell(dgShowData,row, index);
        TextBlock c = (TextBlock)columnCell.Content;
        txtNameEdit.Text = c.Text;
     }
    /// <summary>
            /// Gets the selected row of the DataGrid
            /// </summary>
            /// <param name="grid">The DataGrid instance</param>
            /// <returns></returns>
            public static DataGridRow GetSelectedRow(this DataGrid grid)
            {
                return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
            }
     /// <summary>
            /// Gets the specified cell of the DataGrid
            /// </summary>
            /// <param name="grid">The DataGrid instance</param>
            /// <param name="row">The row of the cell</param>
            /// <param name="column">The column index of the cell</param>
            /// <returns>A cell of the DataGrid</returns>
            public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
            {
                if (row != null)
                {
                    DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
    
                    if (presenter == null)
                    {
                        grid.ScrollIntoView(row, grid.Columns[column]);
                        presenter = GetVisualChild<DataGridCellsPresenter>(row);
                    }
    
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
    
                    return cell;
                }
                return null;
            }
