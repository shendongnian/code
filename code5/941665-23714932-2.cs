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
    
    
    namespace StackOverflowWPF
    {
       /// <summary>
       /// Interaction logic for MainWindow.xaml
       /// </summary>
       public partial class MainWindow : Window
       {
          public MainWindow()
          {
             InitializeComponent();
          }
    
          private void Button_Click_1(object sender, RoutedEventArgs e)
          {
             this.Top = 0;
             this.Left = 0;
             System.Drawing.Rectangle screenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
             this.Width = screenBounds.Width / 2;
             this.Height = screenBounds.Height;
          }
       }
    }
