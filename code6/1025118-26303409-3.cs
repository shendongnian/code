    string strNumber;
    public MainWindow()
    {
        InitializeComponent();
        MyNumpad numpad = new MyNumpad();
        numpad.button1.AddHandler(Button.ClickEvent, new RoutedEventHandler(
            (s, e) => 
            {
                //suppose there is a TextBox in the page to accept user input
                strNumber = numpad.InputTextBox.Text; 
                popupDialog.IsOpen = false;
                mainDisplay.IsEnabled = true; 
            }), false);
        frame1.Navigate(numpad);
    } 
