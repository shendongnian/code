    using System.Windows;
    namespace CEF
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void browser_IsBrowserInitializedChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                // the browser control is initialized, now load the html
                browser.LoadHtml("<html><head></head><body><h1>Hello, World!</h1></body></html>", "http://www.example.com/");
            }
        }
    }
