    // <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                this.InitialiseData();
    
                InitializeComponent();
            }
    
            public ObservableCollection<MyNode> Items { get; set; }
    
            public void InitialiseData()
            {
                Items = new ObservableCollection<MyNode>
                {
                    new MyNode
                    {
                        Name = "one",
                        Items = new ObservableCollection<MyNode>
                        {
                            new MyNode { Name = "one", IsLeafNode = true },
                            new MyNode { Name = "two", IsLeafNode = true },
                            new MyNode { Name = "three", IsLeafNode = true }
                        }
                    },
                    new MyNode
                    {
                        Name = "two",
                        Items = new ObservableCollection<MyNode>
                        {
                            new MyNode { Name = "one", IsLeafNode = true },
                            new MyNode { Name = "two", IsLeafNode = true },
                            new MyNode { Name = "three", IsLeafNode = true }
                        }
                    },
                    new MyNode { Name = "three", IsLeafNode = true }
                };
            }
        }
