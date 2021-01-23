    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Visibility _visibility1;
        public Visibility Visibility1
        {
            get { return _visibility1; }
            set
            {
                _visibility1 = value;
                OnPropertyChanged();
            }
        }
        private Visibility _visibility2;
        public Visibility Visibility2
        {
            get { return _visibility2; }
            set
            {
                _visibility2 = value;
                OnPropertyChanged();
            }
        }
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
    public partial class MainWindow : Window
    {
        private ViewModel _vm = new ViewModel() { Visibility1 = Visibility.Visible, Visibility2 = Visibility.Collapsed };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _vm.Visibility1 = Visibility.Collapsed;
            _vm.Visibility2 = Visibility.Visible;
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _vm.Visibility1 = Visibility.Visible;
            _vm.Visibility2 = Visibility.Collapsed;
        }
    }
