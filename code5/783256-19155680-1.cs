     public ObservableCollection<ListViewItemsData> ListViewItemsCollections { get { return _ListViewItemsCollections; } }
        ObservableCollection<ListViewItemsData> _ListViewItemsCollections = new ObservableCollection<ListViewItemsData>();
        public MainWindow()
        {
            InitializeComponent();
            ListViewItemsCollections.Add(new ListViewItemsData()
            {
                GridViewColumnName_ImageSource = @"D:\rd\C Sharp\general\StackOverFlowAnswers\WPF\MSD.JPG",
                GridViewColumnName_LabelContent = "shanmugharaj"
            });
            ListView1.ItemsSource = ListViewItemsCollections;
        }
        public class ListViewItemsData
        {
            public string GridViewColumnName_ImageSource { get; set; }
            public string GridViewColumnName_LabelContent { get; set; }
            public string GridViewColumnName_ID { get; set; }
            public string GridViewColumnTags { get; set; }
            public string GridViewColumnLocation { get; set; }
        }
    }
