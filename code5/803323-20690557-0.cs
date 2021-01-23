    #region ShowCountry
    public static readonly DependencyProperty ShowCountryProperty = DependencyProperty.Register
    (
    	"ShowCountry",
    	typeof(bool),
    	typeof(CountryAndSubdivisionFilter),
    	new PropertyMetadata(true, OnShowCountryPropertyChanged)
    );
    public bool ShowCountry
    {
    	get
    	{
    		return (bool) GetValue(ShowCountryProperty);
    	}
    	set
    	{
    		SetValue(ShowCountryProperty, value);
    
    		this.CountryStackPanel.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
    		this.SetMargins();
    	}
    }
    private static void OnShowCountryPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
    	var ctrl = d as CountryAndSubdivisionFilter;
    	ctrl.ShowCountry = (bool) e.NewValue;
    }
    #endregion
