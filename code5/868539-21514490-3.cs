    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;//<-------- notice this
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
    namespace DUALBIND
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random r = new Random();//best use of random
        ObservableCollection<IGeneralInfo> generalinfo = new ObservableCollection<IGeneralInfo>();
        public MainWindow()
        {
            InitializeComponent();
            infolist.DataContext = generalinfo;
            generalinfo.Add(new OBJA());
            generalinfo.Add(new OBJA());
            generalinfo.Add(new OBJA());
            generalinfo.Add(new OBJB(7));
            generalinfo.Add(new OBJB(6));
            generalinfo.Add(new OBJB(12345));
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            /*this was set up for you to play with*/           
            MessageBox.Show("You get to mess with this");
            generalinfo.Add(new OBJB(MainWindow.r.Next()));
        }
    }
    }
