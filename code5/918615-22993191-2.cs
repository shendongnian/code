    public double ThresholdRatio
    {
        get { return (double) GetValue( ThresholdRatioProperty ); }
        set { SetValue( ThresholdRatioProperty, value ); }
    }
    public static readonly DependencyProperty ThresholdRatioProperty =
        DependencyProperty.Register( "ThresholdRatio", typeof(double),
        typeof( MainPage), new PropertyMetadata(HandleThresholdRatioChanged) );
    private static void HandleThresholdRatioChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MainPage)d).RaiseThresholdRatioChanged();
    }
    private void RaiseThresholdRatioChanged()
    {
        var handlers = ThresholdRatioChanged;
        if (handlers!=null) handlers(this,EventArgs.Empty);
    }
    public event EventHandler ThresholdRatioChanged;
