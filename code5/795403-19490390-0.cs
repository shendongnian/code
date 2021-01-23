      public partial class MainWindow : Window
    {
        private ExampleViewModel m_ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            m_ViewModel = new ExampleViewModel();
            this.DataContext = m_ViewModel;
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {
            m_ViewModel.RiskHighLowMedium = true;
        }
    }
    public class ExampleViewModel : INotifyPropertyChanged
    {
        private bool _riskHighLowMedium = false;
        public ExampleViewModel()
        {
        }
        public bool RiskHighLowMedium
        {
            get 
            { 
                return _riskHighLowMedium; 
            }
            set
            {
                _riskHighLowMedium = value;
                OnPropertyChanged("RiskHighLowMedium");
            }
        }
        public Brush Background
        {
            get
            {
                return RiskHighLowMedium ? Brushes.Red : Brushes.Blue;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
     <Style x:Key="CircleButtonStyle" TargetType="Button">
            <Setter Property="Background" Value="{Binding Path=Background, Mode=OneWay}"/>
            <Style.Triggers>
                <DataTrigger Binding="{Binding RiskHighLowMedium}"  Value="True">
                    <Setter Property="Background" Value="{ Binding Path= Background, Mode=OneWay}"/>
                </DataTrigger>
            </Style.Triggers>
        </Style>
      <Grid>
        <Button Name="btn" Height="40" Width="180" Content="Hello" Style="{StaticResource CircleButtonStyle}" Click="btn_Click"></Button>
    </Grid>
