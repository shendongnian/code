    namespace filter
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<myProcess> myCollection;
            public MainWindow()
            {
                InitializeComponent();
    
                myProcesses items = new myProcesses();
                myCollection = new ObservableCollection<myProcess>();
                foreach (myProcess localproc in items.GetProcesses)
                {
                    myCollection.Add(localproc);
                }
                lvUsers.ItemsSource = myCollection;
    
                CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(myCollection);
                view.Filter = UserFilter;
            }
    
            private bool UserFilter(object item)
            {
                if (String.IsNullOrEmpty(txtFilter.Text))
                    return true;
                else
                    return ((item as myProcess).Name.IndexOf(txtFilter.Text, StringComparison.OrdinalIgnoreCase) >= 0);
            }
    
            private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
            {
                CollectionViewSource.GetDefaultView(myCollection).Refresh();
            }
        }
    
    }
