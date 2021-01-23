    public sealed partial class MainPage : Page
    {
        // create the view model
        MyViewModel vm = new MyViewModel();
        public MainPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            // set the text we initial want to display
            vm.FooterTitle = "default text";
            // set the DataContext of the textbox to the ViewModel
            tb.DataContext = vm;
        }
        // after the button is click we change the TextBox's Text
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // change the text
            vm.FooterTitle = "Test Property Has Changed.";
            // what happens is the Setter of the Property is called first
            // after that happens it launches the `OnFooterTitlePropertyChanged` event
            // that we hook up with the Register function.
           
            // `OnFooterTitlePropertyChanged` launches the INotifyPropertyChanged event
            // then finally the TextBox will updates it's layout
        }
    }
