    gridview1.LeftCoord = (gridview1.FocusedColumn.VisibleIndex - visibleColumnsCount / 2) * gridview1.VisibleColumns[0].Width;
    
    Visiblecolumnscount = // count of currently visible columns in the view 
    
      public int GetVisibleColumnCount(GridView view)
            {
                GridViewInfo info = view.GetViewInfo() as GridViewInfo;
                int visibleColumnCount = 0;
    
                for (int i = 0; i < view.VisibleColumns.Count; i++)
                {
                    if (info.GetColumnLeftCoord(view.GetVisibleColumn(i))
                        < view.ViewRect.Width - info.ViewRects.IndicatorWidth)
    
                        visibleColumnCount++;
                }
                return visibleColumnCount;
            }
