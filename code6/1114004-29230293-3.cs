    public IEnumerable<string> Buttons { get; set; }
    private Dictionary<string, string> MyDict = new Dictionary<string, string> { { "First", "MyFirst" }, { "Second", "MySecond" } };
    public MainWindow() {
        this.DataContext = this;
        Buttons = MyDict.Keys;
        InitializeComponent();
    }
