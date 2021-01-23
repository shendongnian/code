    namespace Wpf1
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new personalApp();
        }
    }
    internal class personalApp : INotifyPropertyChanged
    {
        private Person person = new Person();
        public string FirstName
        {
            get { return person.FirstName; }
            set
            {
                person.FirstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(
                this, new PropertyChangedEventArgs(propName));
        }
    }
    internal class Person
    {
        public string FirstName { get; set; }
    }
    }
