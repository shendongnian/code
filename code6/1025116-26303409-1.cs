    string strNumber;
    public MainWindow()
    {
        InitializeComponent();
        MyNumpad numpad = new MyNumpad();
        page1.button1.AddHandler(Button.ClickEvent, new RoutedEventHandler(
            (s, e) => 
            {
                //suppose there is a TextBox in the page to accept user input
                strNumber = page1.InputTextBox.Text; 
                popupDialog.IsOpen = false;
                mainDisplay.IsEnabled = true; 
            }), false);
        frame1.Navigate(page1);
    } 
