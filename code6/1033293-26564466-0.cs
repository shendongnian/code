        private void OnDataGridMouseUp(object o, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer)
            {
                ((DataGrid) o).UnselectAll();
            }
        }
