    public partial class MainWindow : Window
    {
        private ObservableCollection<customer> custcol;
        public ObservableCollection<customer> custCol
        {
            get { return custcol; }
            set
            {
                custcol = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            custcol = new ObservableCollection<customer>();
            custCol.Add(new customer { custID = 1, custName = "1", Status = "InActive", Flag = true });
            custCol.Add(new customer { custID = 2, custName = "2", Status = "InActive", Flag = false });
            custCol.Add(new customer { custID = 3, custName = "3", Status = "InActive", Flag = false });
            datagrid1.ItemsSource = this.custCol;
        }
        private void ChkAll_Checked(object sender, RoutedEventArgs e)
        {
        }
        private void ChkAll_Unchecked(object sender, RoutedEventArgs e)
        {
        }
        private void Chk_Checked(object sender, RoutedEventArgs e)
        {
            switch (((sender as CheckBox).Tag as customer).custID)
            {
                case 1: break;
                case 2: break;
                case 3: break;
            }
        }
    }
    public class customer : INotifyPropertyChanged
    {
        public object obj { get; set; }
        public int custID { get; set; }
        private string custname;
        public string custName
        {
            get { return custname; }
            set
            {
                custname = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("custName"));
                }
            }
        }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Status"));
                }
            }
        }
        private string duration;
        public string Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Duration"));
                }
            }
        }
        public bool Flag { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
