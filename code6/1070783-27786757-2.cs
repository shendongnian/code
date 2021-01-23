    public partial class MainWindow : Window
    {
    public ObservableCollection<FieldSample> fieldAnalysis;
    public MainWindow()
    {
        fieldAnalysis = new ObservableCollection<FieldSample>();
        InitializeComponent();
        this.DataContext = this;
    }
