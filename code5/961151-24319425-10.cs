    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        base.OnRender(dc);
        if (Grid == null || Grid.SelectedItems == null)
            return;
        IEnumerable<int> indexes = null;
        if (Grid.SelectedItems.Count == Grid.Items.Count)
        {
            indexes = Enumerable.Range(0, Grid.Items.Count);
        }
        else
        {
            List<int> indexList = new List<int>();
            FieldInfo fi = Grid.GetType().GetField("_selectedItems", BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            IEnumerable<object> internalSelectionList = fi.GetValue(Grid) as IEnumerable<object>;
            PropertyInfo pi = null;
            foreach (var item in internalSelectionList)
            {
                if (pi == null)
                {
                    pi = item.GetType().GetProperty("Index", BindingFlags.Instance | BindingFlags.NonPublic);
                }
                indexList.Add((int)pi.GetValue(item));
            }
            indexList.Sort();
            indexes = indexList;
        }
        double translateDelta = ActualHeight / (double)Grid.Items.Count;
        double width = ActualWidth;
        double height = Math.Max(translateDelta, 4);
        Brush dBrush = MarkerBrush;
        double previous = 0;
        foreach (int itemIndex in indexes)
        {
            double top = itemIndex * translateDelta;
            if (top < previous)
                continue;
            dc.DrawRectangle(dBrush, null, new Rect(0, top, width, height));
            previous = (top + height) - 1;
        }
    }
