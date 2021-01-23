    public sealed partial class FirstView : MvxStorePage
    {
        public new FirstViewModel ViewModel
        {
            get { return (FirstViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
        public FirstView()
        {
            this.InitializeComponent();
            this.Loaded += FirstView_Loaded;
        }
        void FirstView_Loaded(object sender, RoutedEventArgs e)
        {
            ListBox.ItemsSource = ViewModel.Tasklist;
        }
    }
