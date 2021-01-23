    using System.ComponentModel;
    using System.Windows;
    
    namespace WpfApplication19
    {
        public partial class MainWindow : Window
        {
            public FileSource fs { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                fs = new FileSource();
                this.DataContext = fs;
            }
    
            private void btnSetFileToNull_Click(object sender, RoutedEventArgs e)
            {
                fs.File = null;
            }
    
            private void btnSetFileToNotNull_Click(object sender, RoutedEventArgs e)
            {
                fs.File = @"C:\abc.123";
            }
        }
    
        public class FileSource : INotifyPropertyChanged
        {
            private string _file;
            public string File { get { return _file; } set { _file = value; OnPropertyChanges("File"); } }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanges(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
