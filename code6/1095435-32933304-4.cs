    public partial class MainWindow : Window
    {
        private ObservableCollection<FileData> files;
        public MainWindow()
        {
            files = new ObservableCollection<FileData>(
            new DirectoryInfo(@"e:\temp")
                .EnumerateFiles()
                .Select(fi => new FileData { DateCreated = fi.CreationTime, Name = fi.FullName })
            );
            InitializeComponent();
            lvDataBinding.ItemsSource = files;
        }  
