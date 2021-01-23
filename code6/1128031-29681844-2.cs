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
    namespace WpfApplication7
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int bread = Convert.ToInt32(txtBread.Text);
            int capacity = Convert.ToInt32(txtCapacity.Text);
            string printString = "";
            int totalTime = 0;
            int timeInterval = 1;
            while (bread > 0)
            {
                if (bread > capacity)
                {
                    bread -= capacity;
                    totalTime += timeInterval;
                    printString += string.Format("{0} - {1}\n", totalTime, capacity);
                }
                else
                {
                    bread -= capacity;
                    totalTime += timeInterval;
                    printString += string.Format("{0} - {1}", totalTime, capacity);
                    txtResult.Text = printString;
                }
            }
        }
    }
    }
