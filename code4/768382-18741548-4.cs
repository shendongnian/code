        private void DataGrid_OnBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            Point newPosition = new Point();
            if (!(lstvwProductCode.RenderTransform is TransformGroup))
                lstvwProductCode.RenderTransform = new TransformGroup();
            DataGrid dg = GetRowsDataGrid(e.Row);
            if (dg != null)
            {
                double rowX = GetColumnXPosition(e.Column, dg);
                newPosition = e.Row.TranslatePoint(new Point(rowX + 5, e.Row.ActualHeight), this);
            }
            if (newPosition != new Point())
            {
                Point tPoint = lstvwProductCode.TranslatePoint(new Point(0, 0), this);
                ((TransformGroup) lstvwProductCode.RenderTransform).Children.Add(
                    new TranslateTransform(newPosition.X - tPoint.X, newPosition.Y - tPoint.Y));
            }
        }
        private double GetColumnXPosition(DataGridColumn column, DataGrid grid)
        {
            double result = 0.0;
            if (grid == null)
                return result;
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                DataGridColumn dgc = grid.Columns[i];
                if (dgc.Equals(column))
                    break;
                result += dgc.ActualWidth;
            }
            return result;
        }
        private DataGrid GetRowsDataGrid(DataGridRow row)
        {
            DependencyObject result = VisualTreeHelper.GetParent(row);
            while (result != null && !(result is DataGrid))
            {
                result = VisualTreeHelper.GetParent(result);
            }
            return result as DataGrid;
        }
