    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        private void NullButton_Click(object sender, RoutedEventArgs e)
        { this.State = null; }
        private void FalseButton_Click(object sender, RoutedEventArgs e)
        { this.State = false; }
        private void TrueButton_Click(object sender, RoutedEventArgs e)
        { this.State = true; }
        bool? _State = null;
        public bool? State { get { return _State; } set { SetProperty(ref _State, value); } }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] String propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
