    public static readonly new DependencyProperty TodaysDateProperty=
                DependencyProperty.Register("TodaysDate", typeof(DateTime), typeof(DateRangeSelectorControl), new PropertyMetadata(null, TodaysDateChanged));
    
    public new DateTime TodaysDate
    {
        get { return (DateTime)GetValue(TodaysDateProperty); }
        set { SetValue(TodaysDateProperty, value); }
    }
    
    private static void TodaysDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((DateRangeSelectorControl)d).TodaysDateChanged((DateTime)e.NewValue);
    }
    private void TodaysDateChanged(DateTime newDate)
    {
        //update your control here
    }
