        private void DataGrid_OnDrop(object sender, DragEventArgs e)
        {
            DataGridRow dataGridRow = null;
            var point = e.GetPosition(null);
            var elements = VisualTreeHelper.FindElementsInHostCoordinates(point, theDataGrid);
            if (elements != null && elements.Count() > 0)
            {
                var rowQuery = from gridRow in elements where gridRow is DataGridRow select gridRow as DataGridRow;
                dataGridRow = rowQuery.FirstOrDefault();
            }
        }
