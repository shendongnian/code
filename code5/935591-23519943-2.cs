    public TemperatureObsControl()
    {
        this.InitializeComponent();
        TemperatureSlider.ValueChanged += TemperatureSlider_ValueChanged; // here you subscribe
        TemperatureSlider.Value = 37; // here you change
        ContinueButton.Content = "No Change";
        ContinueButton.Visibility = Visibility.Collapsed;
    }
