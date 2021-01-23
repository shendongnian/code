    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaktionslogik für MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                DataContext = new myPointClass(100, 200);
                InitializeComponent();
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                MessageBox.Show(((myPointClass)DataContext).X + "=X |  Y=" + ((myPointClass)DataContext).Y);
            }
    
            public class myPointClass
            {
                public int X { get; set; }
                public int Y { get; set; }
    
                public myPointClass(int x, int y)
                {
                    this.X = x; this.Y = y;
                }
            }
    
        }
    }
