    namespace WpfTestBench
    {
        public partial class OpenFileWindow
        {
            public OpenFileWindow()
            {
                InitializeComponent();
    
                DataContext = this;
            }
    
            public string SelectedFilename { get; set; }
        }
    }
