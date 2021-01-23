    public MainWindow()
    {
        InitializeComponent();
    
        XmlDocument doc = new XmlDocument();
        doc.Load("http://store.tymesheet.com/templates/Software-Developer.xml");
        var taskList = doc.ChildNodes.OfType<XmlNode>()
                        .Where(node => node.Name == "tasks")
                        .SelectMany(node => node.ChildNodes.OfType<XmlNode>());
        Tasks = new ObservableCollection<XmlNode>(taskList);
    
        this.DataContext = this;
    }
    
    public ObservableCollection<XmlNode> Tasks { get; set; }
    private void deletebuttonclick(object sender, RoutedEventArgs e)
    {
       XmlNode selectedNode = ((Button)sender).DataContext as XmlNode;
       Tasks.Remove(selectedNode);
    }
