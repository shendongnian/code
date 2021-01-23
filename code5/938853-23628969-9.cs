    using System;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = new MainViewModel();
            }
        }
