    using GalaSoft.MvvmLight.Command;
    using OxyPlot;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
    
    namespace WpfApplication15
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class DataLoading
    {
        public PlotModel PlotModel { get; set; }
        public ICommand TestCommand { get; set; }
        OxyPlot.Axes.LinearAxis X;
        OxyPlot.Axes.LinearAxis Y;
        private OxyPlot.Series.LineSeries FirstSeries;
        private OxyPlot.Series.LineSeries SecondSeries;
        private int i =0;
        public DataLoading()
        {
            TestCommand = new RelayCommand(()=>ShowActualPoints());
            PlotModel = new PlotModel();
            X = new OxyPlot.Axes.LinearAxis()
            {
                Position = OxyPlot.Axes.AxisPosition.Bottom,
                Minimum=1,
                Maximum=5
            };
            Y = new OxyPlot.Axes.LinearAxis()
            {
                Position = OxyPlot.Axes.AxisPosition.Left,
                IsPanEnabled = false
            };
            FirstSeries = new OxyPlot.Series.LineSeries();
            SecondSeries = new OxyPlot.Series.LineSeries();
            FirstLoad();
            PlotModel.Axes.Add(X);
            PlotModel.Axes.Add(Y);
            OxyPlot.Wpf.PlotView PV = new OxyPlot.Wpf.PlotView();
            PlotModel.Axes[0].AxisChanged += (o, e) =>
            {
                double LastPoint = (from y in FirstSeries.Points select y.X).Min();
                ShowActuals(LastPoint);
            };
        }
        public delegate void BeginUpdate();
        public void ShowActuals(double inputlastpoint)
        {
            if (inputlastpoint > PlotModel.Axes[0].ActualMinimum)
            {
                Debug.WriteLine("Need to load points");
                BeginUpdate BU = new BeginUpdate(SecondLoad);
                IAsyncResult result = BU.BeginInvoke(null,null);
            }
            else
            {
                Debug.WriteLine("No need to load points");
            }
        }
        private void FirstLoad()
        {
            FirstSeries.Points.Add(new DataPoint(1, 1));
            FirstSeries.Points.Add(new DataPoint(2, 2));
            FirstSeries.Points.Add(new DataPoint(3, 3));
            FirstSeries.Points.Add(new DataPoint(4, 3));
            FirstSeries.Points.Add(new DataPoint(5, 3));
            PlotModel.Series.Add(FirstSeries);
        }
        private void SecondLoad()
        {
            Random rnd = new Random();
            FirstSeries.Points.Insert(0,new DataPoint(--i, rnd.NextDouble()));
            System.Threading.Thread.Sleep(1000);
            PlotModel.InvalidatePlot(true);
        }
        private void ShowActualPoints()
        {
            Debug.WriteLine("Y:{0}",PlotModel.Axes[1].ActualMaximum);
            Debug.WriteLine("X:{0}", PlotModel.Axes[0].ActualMaximum);
            Debug.WriteLine(PlotModel.Series[0].GetNearestPoint(new ScreenPoint(PlotModel.Axes[0].ActualMaximum, PlotModel.Axes[1].ActualMaximum), false));
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext= new DataLoading();
        }
    }
}
