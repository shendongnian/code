    using System.Windows;
    namespace WpfApplication5 {
        public partial class Window1 : Window {
            public Window1() {
                InitializeComponent();
                grid.DataSource = ProductList.GetData();
            }
            private void Window_Loaded(object sender, RoutedEventArgs e) {
                DevExpress.Xpf.Core.ThemeManager.ApplicationThemeName = "Office2007Black"; //set theme here 
            }
        }
    }
