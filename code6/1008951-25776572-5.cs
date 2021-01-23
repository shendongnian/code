    public partial class MainWindow : Window
    {
        private sample_viewmodel viewmodel;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sample_viewmodel viewmodel = new sample_viewmodel();  // create the view model
            myListView.DataContext = viewmodel;                   // set the datacontext (this will link the commands)
            myListView.ItemsSource = viewmodel.DataSource;        // set the ItemsSource, this will link the Artist,Songs
        }
        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            // only for testing purpose, don't actually use this code
            myListView.SelectedItem = (sample_model) ((ObservableCollection<sample_model>)myListView.ItemsSource)[2];
            // or you can do this
            // viewmodel.SelectedItem = (sample_model)((ObservableCollection<sample_model>)myListView.ItemsSource)[2];
            // or this
            // viewmodel.SelectedItem = viewmodel.DataSource[2];
            myListView.Focus();            
        }
    }
