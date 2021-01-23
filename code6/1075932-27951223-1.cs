    public partial class SomeWindow : Window
    {
        private void OnGenericViewRequested(object sender, GenericViewRequestedEventArgs e)
        {
            GenericWindow window = new GenericWindow(e.ViewModel);
            window.Owner = this;
            window.ShowDialog();
        }
        public SomeWindow()
        {
            InitializeComponent();
            
            var viewModel = new SomeViewModel();
            viewModel.GenericViewRequested += OnGenericViewRequested;
            this.DataContext = viewModel;
        }
    }
