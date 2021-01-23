    private class DataClass
    {
        public string Text { get; set; }
    }
    public MainWindow()
    {
        InitializeComponent();
        var doc = LoadFlowDocument("DocWithBinding.xaml");
        doc.DataContext = new DataClass { Text = "Hello, World." };
        rtb.Document = doc;
    }
    private static FlowDocument LoadFlowDocument(string path)
    {
        using (var xamlFile = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            return XamlReader.Load(xamlFile) as FlowDocument;
        }
    }
