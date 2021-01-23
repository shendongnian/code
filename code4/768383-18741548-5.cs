        private void DataGrid_OnBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            Point newPosition = new Point();
            if (!(lstvwProductCode.RenderTransform is TransformGroup))
                lstvwProductCode.RenderTransform = new TransformGroup();// set the ListView's RenderTransform to a TransformGroup if it isn't already
            DataGrid dg = GetRowsDataGrid(e.Row); //get the Row's corresponding DataGrid with the help of the VisualTreeHelper. You cant use the Column here, because it won't get added to the visual tree.
            if (dg != null)
            {
                double rowX = GetColumnXPosition(e.Column, dg); //get the x position. Here you can't use .TranslatePoint because - again - it doesn't belong to the visual tree, so you have to sum up all columns width' to the column where the changes are made.
                newPosition = e.Row.TranslatePoint(new Point(rowX + 5, e.Row.ActualHeight), this); //translate this point to a point on your main window.
            }
            if (newPosition != new Point())
            {
                Point tPoint = lstvwProductCode.TranslatePoint(new Point(0, 0), this);//add this point
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
