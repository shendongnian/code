    public AboutPage()
    {
       this.InitializeComponent();
       HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
       var frame = Window.Current.Content as Frame;
       if (frame.CanGoBack)
       {
          var navigation = ServiceLocator.Current.GetInstance<INavigationService>();
                navigation.GoBack();
                e.Handled = true;
       }
     }
