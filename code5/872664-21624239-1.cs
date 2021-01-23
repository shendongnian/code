    private int taps = 0;
    public MainPage()
    {
        InitializeComponent();
        ContentPanel.MouseLeftButtonDown += ContentPanel_MouseLeftButtonDown;
        ContentPanel.MouseLeftButtonUp += ContentPanel_MouseLeftButtonUp;
    }
    private void ContentPanel_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
       taps++;
       counter.Text = taps.ToString(); //convert var from int to string
       Touched.Visibility = Visibility.Collapsed;
    }
    private void ContentPanel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        Touched.Visibility = Visibility.Visible;
    }
    // method to reset the counter to zero when button is pressed and released
    private void Button_Click(object sender, RoutedEventArgs e)
    {
       taps = 0; // reset the count
       counter.Text = taps.ToString(); // convert var from int to string
    }
