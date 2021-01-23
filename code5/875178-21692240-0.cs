    public partial class MainWindow : Window
    {
        private Cell cell = new Cell();
        public MainWindow()
        {
            InitializeComponent();
            b.DataContext = cell;
            b.Background = Brushes.White;
            Binding binding = new Binding("CellState");
            StateToBrushConverter stateConverter = new StateToBrushConverter();
            binding.Converter = stateConverter;
            Cell c = (Cell)b.DataContext;
            binding.ConverterParameter = c.CellState;
            b.SetBinding(Button.BackgroundProperty, binding);
        }
        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            this.cell.CellState = (bool) checkBox1.IsChecked ? State.ALIVE : State.DEAD;
        }
    }
    public enum State { ALIVE, DEAD }
    public class Cell : INotifyPropertyChanged
    {
        private State state;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public State CellState
        {
            get { return this.state; }
            set
            {
                if (value != this.state)
                {
                    this.state = value;
                    NotifyPropertyChanged("CellState");
                }
            }
        }
    }
    [ValueConversion(typeof(State), typeof(String))]
    public class StateToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush b = null;
            State s = (State)value;
            if (s == State.ALIVE)
            {
                b = Brushes.Black;
            }
            else if (s == State.DEAD)
            {
                b = Brushes.White;
            }
            return b;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
