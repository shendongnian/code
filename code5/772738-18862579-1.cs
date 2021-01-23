    public int TileColumns
    {
        get { return (int)GetValue(TileColumnsProperty); }
        set { SetValue(TileColumnsProperty, value); }
    }
    
    // Using a DependencyProperty as the backing store for TileColumns.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TileColumnsProperty =
        DependencyProperty.Register("TileColumns", typeof(int), typeof(TileView), new PropertyMetadata(3));
    
    private void scroll_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        var aw = scroll.ActualWidth;
        TileColumns = (int)aw / 154; // 154 is a Tile's width
    }
