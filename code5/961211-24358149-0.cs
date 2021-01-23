    namespace WpfChartExample
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<ChartData> chartData;
            ChartData objChartData;
            Thread MyThread;
            public MainWindow()
            {
                InitializeComponent();
                chartData = new ObservableCollection<ChartData>();
                DateTime dtnow = DateTime.Now;
                objChartData = new ChartData() { Name = dtnow, Value = 0.0 };
                chartData.Add(objChartData);
                chartData.Add(new ChartData() { Name = (dtnow + TimeSpan.FromSeconds(2)), Value = new Random().NextDouble() * 100 });
                chartData.Add(new ChartData() { Name = (dtnow + TimeSpan.FromSeconds(4)), Value = new Random().NextDouble() * 100 });
                xAxis.Minimum = chartData[0].Name;
                simChart.DataContext = chartData;
                MyThread = new Thread(new ThreadStart(StartChartDataSimulation));
            }
            public void StartChartDataSimulation()
            {
                int i = 0;
                while (true)
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        var data = new ChartData() { Name = DateTime.Now, Value = new Random().NextDouble() * 100 };
                        chartData.Add(data);
                        if (chartData.Count % 40 == 0 && i == 0)
                        {
                            xAxis.Minimum = chartData[i + 1].Name;
                            i++;
                        }
                        if (i >= 1)
                        {
                            xAxis.Minimum = chartData[i + 1].Name;
                            i++;
                        }
                    }));
                    Thread.Sleep(1000);
                }
            }
            private void btnStartStop_Click(object sender, RoutedEventArgs e)
            {
                if ((string)btnStartStop.Content == "Start Simulation")
                {
                    if (MyThread.ThreadState == ThreadState.Unstarted)
                    {
                        MyThread.Start();
                    }
                    else if (MyThread.ThreadState == ThreadState.Suspended)
                    {
                        MyThread.Resume();
                    }
                    btnStartStop.Content = "Stop Simulation";
                }
                else
                {
                    MyThread.Suspend();
                    btnStartStop.Content = "Start Simulation";
                }
            }
    
            private void Window_Closing(object sender, CancelEventArgs e)
            {
                if (MyThread.ThreadState == ThreadState.Running ||MyThread.ThreadState == ThreadState.WaitSleepJoin)
                {
                    MyThread.Suspend();
                }
                Application.Current.Shutdown();
            }
       
        }
        public class ChartData : INotifyPropertyChanged
        {
            DateTime _Name;
            double _Value;
            #region properties
            public DateTime Name
            {
                get
                {
                    return _Name;
                }
                set
                {
                    _Name = value;
                    OnPropertyChanged("Name");
                }
            }
            public double Value
            {
                get
                {
                    return _Value;
                }
                set
                {
                    _Value = value;
                    OnPropertyChanged("Value");
                }
            }
            #endregion
            public event PropertyChangedEventHandler PropertyChanged;
            private void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        
        }
    }
    <Window x:Class="WpfChartExample.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:chrt="clr-namespace:System.Windows.Controls.DataVisualization.Charting;assembly=System.Windows.Controls.DataVisualization.Toolkit"
        Title="MainWindow" Height="350" Width="525" Closing="Window_Closing">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>
        <chrt:Chart x:Name="simChart" Title="Simulation" Background="Beige">
            <chrt:LineSeries IndependentValueBinding="{Binding Name}" 
                             DependentValueBinding="{Binding Value}" 
                             ItemsSource="{Binding}"
                             Background="DarkGray">
                <chrt:LineSeries.DataPointStyle>
                    <Style TargetType="{x:Type chrt:LineDataPoint}">
                        <Setter Property="BorderBrush" Value="Red" />
                        <Setter Property="Width" Value="5" />
                        <Setter Property="Height" Value="5" />
                        <Setter Property="Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="chrt:LineDataPoint">
                                    <Grid x:Name="Root" Opacity="1">
                                        <ToolTipService.ToolTip>
                                            <StackPanel Margin="2,2,2,2">
                                                <ContentControl Content="{TemplateBinding IndependentValue}" 
                                            ContentStringFormat="X-Value: {0:HH:mm:ss}"/>
                                                <ContentControl Content="{TemplateBinding DependentValue}" 
                                            ContentStringFormat="Y-Value: {0:###.###}"/>
                                            </StackPanel>
                                        </ToolTipService.ToolTip>
                                        <Ellipse StrokeThickness="{TemplateBinding BorderThickness}" 
                     Stroke="{TemplateBinding BorderBrush}" 
                     Fill="{TemplateBinding Background}"/>
                                    </Grid>
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </chrt:LineSeries.DataPointStyle>
                <chrt:LineSeries.IndependentAxis>
                    <chrt:DateTimeAxis Name="xAxis" ShowGridLines="True" Orientation="X">
                        <chrt:DateTimeAxis.AxisLabelStyle>
                            <Style TargetType="chrt:DateTimeAxisLabel">
                                <Setter Property="StringFormat" Value="{}{0:mm:ss}" />
                            </Style>
                        </chrt:DateTimeAxis.AxisLabelStyle>
                    </chrt:DateTimeAxis>
                </chrt:LineSeries.IndependentAxis>
                
                <chrt:LineSeries.DependentRangeAxis>
                    <chrt:LinearAxis Orientation="Y" ShowGridLines="True" Minimum="-50" Maximum="50"></chrt:LinearAxis>
                </chrt:LineSeries.DependentRangeAxis>
                <chrt:LineSeries.Title>
                        <TextBlock TextAlignment="Center">Time<LineBreak/>vs.<LineBreak/>Random<LineBreak/>Data</TextBlock>
                    </chrt:LineSeries.Title>
                </chrt:LineSeries>
        </chrt:Chart>
        <Button Name="btnStartStop" Width="Auto" Height="30" Grid.Row="1" HorizontalAlignment="Right" Margin="10" Click="btnStartStop_Click">Start Simulation</Button>
    </Grid>
