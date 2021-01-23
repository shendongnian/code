    public partial class MainWindow : Window
    {
        public static RoutedCommand CloseItemCommand = new RoutedCommand("CloseItem", typeof(MainWindow));
        public MainWindow()
        {
            this.ViewModel = new MyViewModel();
            InitializeComponent();
        }
        public MyViewModel ViewModel { get; set; }
        private void MyListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ViewModel.AddItem(e.AddedItems.OfType<Type>().FirstOrDefault());
        }
        private void CommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.ViewModel.RemoveItem(e.Parameter);
        }
