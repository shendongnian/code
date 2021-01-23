    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        base.OnRender(dc);
        if (Grid == null || Grid.SelectedItems == null)
            return;
        IEnumerable<int> indexes = null;
        double translateDelta = ActualHeight / (double)Grid.Items.Count;
        double height = Math.Max(translateDelta, 4);
        int itemInOneRect = (int)Math.Ceiling(height / translateDelta);
        itemInOneRect -= (int)(itemInOneRect * 0.2);
        if (Grid.SelectedItems.Count == Grid.Items.Count)
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < Grid.Items.Count; i += itemInOneRect)
            {
                indexList.Add(i);
            }
            indexes = indexList;
        }
        else
        {
            List<int> indexList = new List<int>();
            FieldInfo fi = Grid.GetType().GetField("_selectedItems", BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance);
            IEnumerable<object> internalSelectionList = fi.GetValue(Grid) as IEnumerable<object>;
            PropertyInfo pi = null;
            int lastIndex = int.MinValue;
            foreach (var item in internalSelectionList)
            {
                if (pi == null)
                {
                    pi = item.GetType().GetProperty("Index", BindingFlags.Instance | BindingFlags.NonPublic);
                }
                int newIndex = (int)pi.GetValue(item);
                if (newIndex > (lastIndex + itemInOneRect))
                {
                    indexList.Add(newIndex);
                    lastIndex = newIndex;
                }
            }
            indexList.Sort();
            indexes = indexList;
        }
        double width = ActualWidth;
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
