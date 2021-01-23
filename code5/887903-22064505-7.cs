    using System;
    using System.Windows;
    
    namespace WpfApplication
    {
        public partial class MainWindow : Window
        {
            readonly Random _random = new Random();
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            public double ControlWidth
            {
                get { return _random.Next(200, 600); }
            }
        }
    }
