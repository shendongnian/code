    public partial class MainWindow : Window
    {
        public ObservableCollection<string> items { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<string>();
            items.Add(("item1"));
            items.Add(("item2"));
            items.Add(("item3333"));
            items.Add(("item4"));
            items.Add(("item5"));
            items.CollectionChanged += items_CollectionChanged;
            this.DataContext = this;
        }
        void items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var view = lv.View as GridView;
            AutoResizeGridViewColumns(view);
        }
        static void AutoResizeGridViewColumns(GridView view)
        {
            if (view == null || view.Columns.Count < 1) return;
            // Simulates column auto sizing
            foreach (var column in view.Columns)
            {
                // Forcing change
                if (double.IsNaN(column.Width))
                    column.Width = 1;
                column.Width = double.NaN;
            }
        }
        private void btnAddItem_OnClick(object sender, RoutedEventArgs e)
        {
            items.Add("aaaaaaaaaabbbbbbb");
        }
    }
