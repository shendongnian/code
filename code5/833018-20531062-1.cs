    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var path = @"C:\";
            var dirs = Directory.GetDirectories(path)
                                .Select(x => new DirectoryInfo(x))
                                .Select(x => new FileViewModel()
                                {
                                    Name = x.Name,
                                    Path = x.FullName,
                                    IsFile = false,
                                });
            var files = Directory.GetFiles(path)
                                   .Select(x => new FileInfo(x))
                                   .Select(x => new FileViewModel()
                                   {
                                       Name = x.Name,
                                       Path = x.FullName,
                                       Size = x.Length,
                                       IsFile = true,
                                   });
           DataContext = dirs.Concat(files).ToList();
        }
    }
