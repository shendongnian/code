    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new MyViewModel(); 
            }
        }
    }
