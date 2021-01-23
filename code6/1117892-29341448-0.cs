    using OxyPlot;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
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
    using System.ComponentModel;
    namespace WpfApplication12
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private Dictionary<string, IList<DataPoint>> testSeries;
        public Dictionary<string, IList<DataPoint>> TestSeries
        {
            get { return testSeries; }
            set { testSeries = value; NotifyPropertyChanged("TestSeries"); }
        }
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public MainWindow()
        {
            TestSeries = new Dictionary<string, IList<DataPoint>>();
            TestSeries.Add("1", new List<DataPoint> { new DataPoint(1, 2), new DataPoint(2, 3) });
            TestSeries.Add("2", new List<DataPoint> { new DataPoint(1, 3), new DataPoint(2, 1) });
            this.DataContext = this;
            InitializeComponent();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    }
