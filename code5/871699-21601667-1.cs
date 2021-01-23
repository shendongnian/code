     /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ChartController _chartController = new ChartController();
            public bool paused; 
    
            public MainWindow()
            {
                InitializeComponent();
    
            }
    
            private void PlayPauseButton_OnClick(object sender, RoutedEventArgs e)
            {
                paused = !paused;
                if (!paused)
                {
                    _chartController.CancelAnim();
                }
                else
                _chartController.StartTask();
            }
        }
    
        public class ChartController
    
        {
            private CancellationTokenSource tokenSource = new CancellationTokenSource();
            private CancellationToken _cancellationToken;
    
            private int reachedChartIndex = 0;
            public void CancelAnim()
            {
                tokenSource.Cancel();
            }
            public ChartController()
            {
    
            }
    
            public void StartTask()
            {
                Task t = Task.Factory.StartNew(() => plotChartPoints(), tokenSource.Token);
                _cancellationToken = tokenSource.Token;
    
    
                //to handle exeption if there is 
                try
                {
                    t.Wait();
                }
                catch (AggregateException e)
                {
                    foreach (var v in e.InnerExceptions) 
                    //here manage task exception 
                }
            }
    
    
    
            public void plotPoint(int x, double y, int series)
            {
                comparisonChart.Series[series].Points.AddXY(x, y);
            }
    
            public void refreshChart()
            {
                this.mainSplitContainer.Panel2.Refresh();
            }
    
            public void plotChartPoints()
            {
    
                _cancellationToken.ThrowIfCancellationRequested();
    
                //comparisonChart.Series[0].Points.DataBindXY(xValuesSeries1.ToArray(), yValuesSeries1.ToArray());
                //comparisonChart.Series[1].Points.DataBindXY(xValuesSeries2.ToArray(), yValuesSeries2.ToArray());
                for (int index = reachedChartIndex; index < xValuesSeries1.Count; index++)
                {
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        reachedChartIndex = index;
                        break;
                    }
                    if (comparisonChart.InvokeRequired)
                    {
                        comparisonChart.Invoke(
                            new MethodInvoker(
                                () => plotPoint(xValuesSeries1.ElementAt(index), yValuesSeries1.ElementAt(index), 0)));
                        comparisonChart.Invoke(
                            new MethodInvoker(
                                () => plotPoint(xValuesSeries2.ElementAt(index), yValuesSeries2.ElementAt(index), 1)));
                    }
                    Thread.Sleep(50);
                    if (this.mainSplitContainer.InvokeRequired)
                    {
                        mainSplitContainer.Invoke(new MethodInvoker(() => refreshChart()));
                    }
    
                }
            }
    
        }
    
    }
