    public partial class YourView : BasePage
    {
        private WhateverYouWantViewModel _viewModel;
    
        public YourView()
        {
            InitializeComponent();
            _viewModel =  new WhateverYouWantViewModel();
            this.DataContext = _viewModel;
        }
    
        private void FetachLatest_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.GetLastestEntries();
        }
    }
