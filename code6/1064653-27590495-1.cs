    using System;
    using System.Collections.Generic;
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
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                LoadItems0();
               
            }
    
            private void LoadItems0()
            {
    
                var items = new[]{
                     new{
                         Description = "Des1",
                         UnitPrice = "1"
                     }
                 };
    
                this.lvItems.ItemsSource = items;
            }
    
            private void _LoadItems()
            {
    
                var items = new[]{
                     new{
                         Description = "Des1",
                         UnitPrice = "1"
                     },
                     new{
                          Description = "Des2",
                         UnitPrice = "2"
                     },
                     new{
                         Description = "Des3",
                         UnitPrice = "3"
                     },
                 };
    
                this.lvItems.ItemsSource = items;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                _LoadItems();
            }
        }
    }
