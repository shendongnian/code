    public partial class MainWindow : Window
        {       
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new SampleViewModel();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                SampleViewModel vm = (SampleViewModel) this.DataContext;
                vm.SampleText = DateTime.Now.Ticks.ToString();
            }
        }
    public class SampleViewModel : INotifyPropertyChanged
        {
            private string _sampleText;
    
            public string SampleText
            {
                get { return _sampleText; }
                set
                {
                    _sampleText = value;
                    OnPropertyChanged();
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;        
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
