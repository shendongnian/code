    public class CompanyMgmtViewModel : TypedViewModelBase<Company>
    {
        private ObservableCollection<Object> _Companies = null;
        private Object[] _selectedCompany = null;
        public Object[] Company
        {
            get { return _selectedCompany; }
            set
            {
                if (_Company != value)
                {
                    _selectedCompany = value;
                }
            }
        }
        public ObservableCollection<Object> Companies
        {
            get { return _Companies; }
            set
            {
                if (_Companies != value)
                {
                    _Companies = value;
                }
            }
        }
        public CompanyMgmtViewModel()
        {
            this.LoadData();
        }
        public void LoadData()
        {
            ObservableCollection<Object> records = new ObservableCollection<Object>();
            var results = AODB.Context.TCompanies.Project().To<Company>();
            foreach (var item in results)
                if (item != null) records.Add(item);
            Companies = records;
        }
    }
