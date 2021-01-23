        void DataGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var datagrid = (System.Windows.Controls.DataGrid)sender;
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(datagrid);
            if (datagrid.SelectedCells.Any())
            {
                DataGridCellInfo firstCellInfo = datagrid.SelectedCells.First();
                FrameworkElement firstElt = firstCellInfo.Column.GetCellContent(firstCellInfo.Item);
                DataGridCellInfo lastCellInfo = datagrid.SelectedCells.Last();
                FrameworkElement lastElt = lastCellInfo.Column.GetCellContent(lastCellInfo.Item);
                if (firstElt != null && lastElt != null)
                {
                    var firstcell = (DataGridCell)firstElt.Parent;
                    var lastCell = (DataGridCell) lastElt.Parent;
                    Point topLeft = datagrid.PointFromScreen(firstcell.PointToScreen(new Point(0, 0)));
                    Point bottomRight = datagrid.PointFromScreen(lastCell.PointToScreen(new Point(lastCell.ActualWidth, lastCell.ActualHeight)));
                    var rect = new Rect(topLeft, bottomRight);
                    if (fillHandleAdorner == null)
                    {
                        fillHandleAdorner = new FillHandleAdorner(datagrid, rect);
                        adornerLayer.Add(fillHandleAdorner);
                    }
                    else
                        fillHandleAdorner.Rect = rect;
                }
            }
            else
            {
                adornerLayer.Remove(fillHandleAdorner);
                fillHandleAdorner = null;
            }
        }
