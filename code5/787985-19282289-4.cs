    namespace WpfApplication1
    {
        using System.Windows;
        using System.ComponentModel;
        using System.Windows.Media;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
                var f = new Form1();
                f.ChangedColourEventHandler += TriggeredChangedColourEventHandler;
                f.Show();
            }
    
            private Brush labelBgColour;
            public Brush LabelBgColour
            {
                get
                {
                    return this.labelBgColour;
                }
                set
                {
                    this.labelBgColour = value;
                    OnPropertyChanged();
                }
            }
    
            private void TriggeredChangedColourEventHandler(object sender, Brush color)
            {
                this.LabelBgColour = color;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName = null)
            {
                var handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
