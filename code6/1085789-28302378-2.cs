    public static readonly DependencyProperty IsClosedProperty =
        DependencyProperty.Register(
            "IsClosed", typeof(bool), typeof(GroupBox),
            new FrameworkPropertyMetadata(false,
                FrameworkPropertyMetadataOptions.AffectsRender,
                (o, e) => ((GroupBox)o).OnIsClosedChanged()));
    public bool IsClosed
    {
        get { return (bool)GetValue(IsClosedProperty); }
        set { SetValue(IsClosedProperty, value); }
    }
    private void OnIsClosedChanged()
    {
        _rowDefContent.Height = new GridLength((IsClosed ? 0 : 1), GridUnitType.Star);
    }
