    protected override void OnRender(System.Windows.Media.DrawingContext dc)
    {
        base.OnRender(dc);
        if (Grid==null || Grid.SelectedItems == null)
            return;
        object[] markers = Grid.SelectedItems.OfType<object>().ToArray();
        double translateDelta = ActualHeight / (double)Grid.Items.Count;
        double width = ActualWidth;
        double height = Math.Max(translateDelta, 4);
        Brush dBrush = MarkerBrush;
        double previous = 0;
        for (int i = 0; i < markers.Length; i++)
        {
            double itemIndex = Grid.Items.IndexOf(markers[i]);
            double top = itemIndex * translateDelta;
            if (top < previous)
                continue;
            dc.DrawRectangle(dBrush, null, new Rect(0, top, width, height));
            previous = (top + height) - 1;
        }
    }
