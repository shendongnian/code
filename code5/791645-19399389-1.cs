    public static readonly DependencyProperty ResultsProperty = DependencyProperty.
        Register("Results", typeof(Dictionary<string, string>), 
        typeof(ItemPairing), new UIPropertyMetadata(Dictionary<string, string>.Empty));
    public Dictionary<string, string> Results
    {
        get { return (Dictionary<string, string>)GetValue(ResultsProperty); }
        set { SetValue(ResultsProperty, value); }
    }
