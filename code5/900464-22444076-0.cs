    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Items.Add(new HumanViewModel());
            Items.Add(new InvaderViewModel());
        }
        private ObservableCollection<BaseViewModel> items;
        public ObservableCollection<BaseViewModel> Items
        {
            get
            {
                if (items == null)
                    items = new ObservableCollection<BaseViewModel>();
                return items;
            }
        }
    }
    public class BaseViewModel : INotifyPropertyChanged
    {
        public virtual string Header
        {
            get { return "BaseViewModel"; }
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
    public class HumanViewModel : BaseViewModel
    {
        public override string Header
        {
            get
            {
                return "HumanViewModel";
            }
        }
    }
    public class InvaderViewModel : BaseViewModel
    {
        public override string Header
        {
            get
            {
                return "InvaderViewModel";
            }
        }
    }
