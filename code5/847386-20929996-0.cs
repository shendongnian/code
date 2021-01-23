    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Forms.Integration;
    
    namespace WpfWinformsTest
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                // add a grid first (optional)
                var grid = new Grid();
                this.Content = grid;
    
                // creating and add a WinForms host
                WindowsFormsHost host = new WindowsFormsHost(); 
                grid.Children.Add(host);
    
                // add a WinForms user control
                var videoStream = new VideoStream();
                host.Child = videoStream;
            }
        }
    }
