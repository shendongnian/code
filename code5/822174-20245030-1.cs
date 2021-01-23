    private bool pickerIsOpen = false;
    // constructor
    public MainPage()
    {
        InitializeComponent();
        this.Loaded += this.MainPageLoaded;
    }
    // page loaded
    private void MainPageLoaded(object sender, RoutedEventArgs e)
    {
        if (this.pickerIsOpen)
        {
            this.MyPopup.IsOpen = true;
            this.pickerIsOpen = false;
        }
    }
    // date/time picker tap
    private void DatePickerTap(object sender, System.Windows.Input.GestureEventArgs e)
    {
        this.pickerIsOpen = true;
    }
