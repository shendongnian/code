      public sealed partial class DisplayNumberPage : Page
    {
        public DisplayNumberPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DisplayNumber.Text = e.Parameter.ToString();
        }
    } 
