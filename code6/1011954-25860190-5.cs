    public partial class MainWindow : Window
    {
        public MainWindow(string filePath)
        {
            InitializeComponent();
            if (filePath != "")
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (var sr = new StreamReader(fs)) txt.Text = sr.ReadToEnd();
        }
    }
