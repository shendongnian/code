        private void GridUpdate(Point position, Rectangle rectangle, FrameworkElement clientWindow)
        {
            var gridPosition = new GridPosition(rectangle.Tag.ToString());
            var oppositeGridPosition = GetOppositeGridPosition(gridPosition);
            var rowHeight = GetMeasure(gridPosition.Row, position.Y, clientWindow.ActualHeight);
            var columnWidth = GetMeasure(gridPosition.Column, position.X, clientWindow.ActualWidth);
            var oppositeRowHeight = GlobalGrid.RowDefinitions[oppositeGridPosition.Row].ActualHeight;
            var oppositeColumnWidth = GlobalGrid.ColumnDefinitions[oppositeGridPosition.Column].ActualWidth;
            GlobalGrid.RowDefinitions[gridPosition.Row].Height = new GridLength(rowHeight);
            GlobalGrid.ColumnDefinitions[gridPosition.Column].Width = new GridLength(columnWidth);
            GlobalGrid.RowDefinitions[oppositeGridPosition.Row].Height = new GridLength(oppositeRowHeight);
            GlobalGrid.ColumnDefinitions[oppositeGridPosition.Column].Width = new GridLength(oppositeColumnWidth);
        }
        private GridPosition GetOppositeGridPosition(GridPosition gridPosition)
        {
            var row = (gridPosition.Row == 0) ? 4 : 0;
            var column = (gridPosition.Column == 0) ? 4 : 0;
            return new GridPosition(row, column);
        }
        private double GetMeasure(int gridPosition, double position, double windowMeasure)
        {
            return gridPosition == 0 ? position : windowMeasure - position;
        }
