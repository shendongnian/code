        public static class DataGridExtension
    {
        public static DataGridColumn GetColumnByIndices(this DataGrid dataGrid, int rowIndex, int columnIndex)
        {
            ValidateParameters(dataGrid, rowIndex, columnIndex);
            var row = dataGrid.GetRowByIndex(rowIndex);
            
            if (row != null)
                return row.GetRowColumnByIndex(columnIndex);
            
            return null;
        }
        public static DataGridCell GetCellByIndices(this DataGrid dataGrid, int rowIndex, int columnIndex)
        {
            ValidateParameters(dataGrid, rowIndex, columnIndex);
            var row = dataGrid.GetRowByIndex(rowIndex);
            if (row != null)
                return row.GetRowCellByColumnIndex(columnIndex);
            return null;
        }
        //TODO:Validate RowIndex
        public static DataGridRow GetRowByIndex(this DataGrid dataGrid, int rowIndex)
        {
            if (dataGrid == null)
                return null;
            return (DataGridRow)dataGrid.ItemContainerGenerator
                                                           .ContainerFromIndex(rowIndex);    
        }
        //TODO:Validate ColumnIndex
        public static DataGridColumn GetRowColumnByIndex(this DataGridRow row, int columnIndex)
        {
            if (row != null)
            {
                var cell=GetRowCellByColumnIndex(row, columnIndex);
                
                if(cell!=null)
                    return cell.Column;
            }
            return null;
        }
        //TODO:Validate ColumnIndex
        public static DataGridCell GetRowCellByColumnIndex(this DataGridRow row, int columnIndex)
        {
            if (row != null)
            {
                DataGridCellsPresenter cellPresenter = row.GetVisualChild<DataGridCellsPresenter>();
                if (cellPresenter != null)
                    return ((DataGridCell)cellPresenter.ItemContainerGenerator.ContainerFromIndex(columnIndex));
            }
            return null;
        }
        private static void ValidateParameters(DataGrid dataGrid,int rowIndex,int columnIndex)
        {
            if (dataGrid == null)
                throw new ArgumentNullException("datagrid is null");
            if (rowIndex >= dataGrid.Items.Count)
                throw new IndexOutOfRangeException("rowIndex out of Index");
            if (columnIndex >= dataGrid.Columns.Count)
                throw new IndexOutOfRangeException("columnIndex out of Index");
        }
    }
