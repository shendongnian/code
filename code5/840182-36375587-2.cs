<!-- -->
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace Login
    {
        /// <summary>
        /// Interaction logic for Page1.xaml
        /// </summary>
        public partial class Page1 : Page
        {
            public Page1()
            {
                InitializeComponent();
            }
            private void buttoncheck_Click(object sender, RoutedEventArgs e)
            {
                Page2 p2 = new Page2();
                p2.textBlock1.Text = txtnavigation.Text;
                //txtnavigatevalue.Text = "";
                NavigationService.Navigate(p2);
            }
        }
    }
