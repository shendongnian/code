    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (dg.ItemsSource as ICollectionView).Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var oc = new ObservableCollection<Wrap>(from i in new[] { 1, 2, 3, 4, 1, 5, 3, 6, 7, 8, 9, 2, 3, 6, 7, 8, 4, 3, 7, 9, 8, 4, 4, 3, 2, 2 }
                                                    select new Wrap { Int = i });
            combo.ItemsSource = Enumerable.Range(1, 9);
            var cvs = new CollectionViewSource();
            cvs.Source = oc;
            cvs.View.Filter = o =>
                {
                    if ((o as Wrap) == null || combo.SelectedItem == null) 
                        return false;
                    return (o as Wrap).Int == ((int)(combo.SelectedItem));
                };
            dg.ItemsSource = cvs.View;
            combo.SelectedIndex = 0;
        }
    }
    class Wrap
    {
        public int Int { get; set; }
    }
