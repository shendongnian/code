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
