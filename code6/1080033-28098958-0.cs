        public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mMngModelList = new ObservableCollection<ManagementFunctionModel>();
            mMngModelList.Add(new ManagementFunctionModel() { RangeLeft = 9 });
            mMngModelList.Add(new ManagementFunctionModel() { RangeLeft = 10 });
            mMngModelList.Add(new ManagementFunctionModel() { RangeLeft = 11 });
            this.DataContext = mMngModelList;
        }
    }
    public class Condition
    {
        public string ConditionString { get; set; }
    }
    public class ManagementFunctionModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region members
        string _Type;
        int _RangeLeft;
        int _RangeTop;
        int _RangeRight;
        int _RangeBottom;
        public ObservableCollection<Condition> _ConditionList { get; private set; }
        #endregion
        public ManagementFunctionModel()
        {
            _ConditionList = new ObservableCollection<Condition>();
            _ConditionList.Add(new Condition() { ConditionString = "condition 1" });
            _ConditionList.Add(new Condition() { ConditionString = "condition 2" });
            _ConditionList.Add(new Condition() { ConditionString = "condition 3" });
        }
        public ObservableCollection<Condition> ConditionList
        {
            get { return _ConditionList; }
            set
            {
                if (_ConditionList != value)
                {
                    _ConditionList = value;
                    RaisePropertyChanged("ConditionList");
                }
            }
        }
        public int RangeLeft
        {
            get { return _RangeLeft; }
            set
            {
                if (_RangeLeft != value)
                {
                    _RangeLeft = value;
                    RaisePropertyChanged("RangeLeft");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }
    }
