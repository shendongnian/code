    namespace MyApp.Extensions
    {
        /// <summary>
        /// Helper methods for the WPF DataGrid.
        /// </summary>
        public static class DataGridExtensions
        {
            /// <summary>
            /// Gets a specific row from the data grid. If the DataGrid is virtualised the row will be scrolled into view.
            /// </summary>
            /// <param name="grid">The DataGrid.</param>
            /// <param name="rowIndex">Row number to get.</param>
            /// <returns></returns>
            public static DataGridRow GetRow(this DataGrid grid, int rowIndex)
            {
                var row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(rowIndex);
                if (row == null)
                {
                    grid.UpdateLayout();
                    grid.ScrollIntoView(grid.Items[rowIndex]);
                    row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(rowIndex);
                }
                return row;
            }
            /// <summary>
            /// Get the selected row.
            /// </summary>
            /// <param name="grid">DataGridRow.</param>
            /// <returns>DataGridRow or null if no row selected.</returns>
            public static DataGridRow GetSelectedRow(this DataGrid grid)
            {
                return (grid.SelectedIndex) < 0 ? null : (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(grid.SelectedIndex);
            }
            /// <summary>
            /// Gets a specific cell from the DataGrid.
            /// </summary>
            /// <param name="grid">The DataGrid.</param>
            /// <param name="row">The row from which to get a cell from.</param>
            /// <param name="column">The cell index.</param>
            /// <returns>A DataGridCell.</returns>
            public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
            {
                if (row == null) return null;
                var presenter = GetVisualChild<DataGridCellsPresenter>(row);
                if (presenter == null)
                {
                    // Virtualised - scroll into view.
                    grid.ScrollIntoView(row, grid.Columns[column]);
                    presenter = GetVisualChild<DataGridCellsPresenter>(row);
                }
                return (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
            }
            /// <summary>
            /// Gets a specific cell from the DataGrid.
            /// </summary>
            /// <param name="grid">The DataGrid.</param>
            /// <param name="row">The row index.</param>
            /// <param name="column">The cell index.</param>
            /// <returns>A DataGridCell.</returns>
            public static DataGridCell GetCell(this DataGrid grid, int row, int column)
            {
                var rowContainer = grid.GetRow(row);
                return grid.GetCell(rowContainer, column);
            }
            /// <summary>
            /// Gets the currently selected (focused) cell.
            /// </summary>
            /// <param name="grid">The DataGrid.</param>
            /// <returns>DataGridCell or null if no cell is currently selected.</returns>
            public static DataGridCell GetSelectedCell(this DataGrid grid)
            {
                var row = grid.GetSelectedRow();
                if (row != null)
                {
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        var cell = grid.GetCell(row, i);
                        if (cell.IsFocused)
                            return cell;
                    }
                }
                return null;
            }
            /// <summary>
            /// Helper method to get a particular visual child.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="parent"></param>
            /// <returns></returns>
            private static T GetVisualChild<T>(Visual parent) where T : Visual
            {
                T child = default(T);
                int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < numVisuals; i++)
                {
                    var v = (Visual)VisualTreeHelper.GetChild(parent, i);
                    child = v as T ?? GetVisualChild<T>(v);
                    if (child != null)
                    {
                        break;
                    }
                }
                return child;
            }
        }
    }
