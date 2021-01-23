    public class ByteModel : INotifyPropertyChanged
    {
        private Byte m_ValueByte = 0xAA;
        public Byte ValueByte
        {
            get
            {
                return this.m_ValueByte;
            }
            set
            {
                if (this.m_ValueByte == value)
                    return;
                this.m_ValueByte = value;
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this,
                        new PropertyChangedEventArgs("ValueByte"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ByteModel();
        }
    }
