    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        } 
        private void lls_ManipulationStateChanged(object sender, EventArgs e)
        {
            if (lls.ScrollDirectionDown)
            {
                ApplicationBar.IsVisible = false;
            }
            else
            {
                ApplicationBar.IsVisible = true;
            }             
        }
    }
