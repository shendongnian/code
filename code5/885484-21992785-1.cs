    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Documents;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                List<string> teste = new List<string>();
                teste.Add("test1");
                teste.Add("test3");
                teste.Add("test2");
    
                TestsListBox.ItemsSource = teste;
    
            }
    
            private void removeTest(object sender, RoutedEventArgs e)
            {
    
            }
        }
    }
