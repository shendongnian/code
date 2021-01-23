    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        DataContext = this;
        var quote = PhoneApplicationService.Current.State["q"];
        QuoteToDisplay = (Quote)quote;
    }
    public static readonly DependencyProperty QuoteToDisplayProperty = DependencyProperty.Register(
        "QuoteToDisplay", typeof (Quote), typeof (MyFilterLogic), new PropertyMetadata(default(Quote)));
    public Quote QuoteToDisplay
    {
        get { return (Quote) GetValue(QuoteToDisplayProperty); }
        set { SetValue(QuoteToDisplayProperty, value); }
    }
