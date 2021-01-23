    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication19
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
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
