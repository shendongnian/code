    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        base.OnRender(dc);
        if (Grid == null || Grid.SelectedItems == null)
            return;
        object[] items = new object[Grid.Items.Count];
        Grid.Items.CopyTo(items, 0);
        object[] selection = new object[Grid.SelectedItems.Count];
        Grid.SelectedItems.CopyTo(selection, 0);
        Dictionary<object, int> indexes = new Dictionary<object, int>();
        for (int i = 0; i < selection.Length; i++)
        {
            indexes.Add(selection[i], 0);
        }
        int itemCounter = 0;
        for (int i = 0; i < items.Length; i++)
        {
            object item = items[i];
            if (indexes.ContainsKey(item))
            {
                indexes[item] = i;
                itemCounter++;
            }
            if (itemCounter >= selection.Length)
                break;
        }
        double translateDelta = ActualHeight / (double)items.Length;
        double width = ActualWidth;
        double height = Math.Max(translateDelta, 4);
        Brush dBrush = MarkerBrush;
        double previous = 0;
        IEnumerable<int> sortedIndex = indexes.Values.OrderBy(v => v);
        foreach (int itemIndex in sortedIndex)
        {
            double top = itemIndex * translateDelta;
            if (top < previous)
                continue;
            dc.DrawRectangle(dBrush, null, new Rect(0, top, width, height));
            previous = (top + height) - 1;
        }
    }
