    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
			var bootstrapper = new Bootstrapper(RootFrame);
			DataContext = bootstrapper.GetMainScreenViewModel();
		}
	}
