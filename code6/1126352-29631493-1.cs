      public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
            this.DataContext = new ViewModel();
        }
    }
    class ViewModel
    {
        private ObservableCollection<Node> myVar;
        public ObservableCollection<Node> NodeList
        {
            get { return myVar; }
            set { myVar = value; }
        }
        public DelegateCommand<Node> TreeNodeDoubleClickevent { get; set; }
        public ViewModel()
        {
            NodeList = new ObservableCollection<Node>();
            Node nd = new Node();
            nd.NodeName = "Item 1.1"; 
            Node nd1 = new Node();
            nd1.NodeName = "Item 1.2";
            Node nd2 = new Node();
            nd2.NodeName = "Item 1";
            nd2.Children.Add(nd);
            nd2.Children.Add(nd1);
            NodeList.Add(nd2);
            TreeNodeDoubleClickevent = new DelegateCommand<Node>(MouseDoubleClick);
        }
        private void MouseDoubleClick(Node obj)
        {
            MessageBox.Show(obj.NodeName);
        }
    }    
    class Node
    {
        private string nodeName;
        public string NodeName
        {
            get { return nodeName; }
            set { nodeName = value;  }
        }     
        
        private ObservableCollection<Node> myVar = new ObservableCollection<Node>();
        public ObservableCollection<Node> Children
        {
            get { return myVar; }
            set { myVar = value; }
        } 
    }
