    class ViewModel : INotifyPropertyChanged
    {
        private readonly List<SearchOperatorLists> dateOperatorList = new List<SearchOperatorLists> 
        {
            new SearchOperatorLists {OperatorName = "Today"},
            new SearchOperatorLists {OperatorName = "Between"},
            new SearchOperatorLists {OperatorName = "Last Month"} 
        };
        private readonly List<SearchOperatorLists> gatewayOperatorList = new List<SearchOperatorLists> 
        {
            new SearchOperatorLists {OperatorName = "Email"},
            new SearchOperatorLists {OperatorName = "RDP"},
            new SearchOperatorLists {OperatorName = "Web"},
            new SearchOperatorLists {OperatorName = "Other"} 
        };
        private SearchCriteriaList selectedCriteriaList;
        public ViewModel()
        {
            this.CriteriaList = new ObservableCollection<SearchCriteriaList> 
            {
                new SearchCriteriaList {SetCriteria = "Date Range"},
                new SearchCriteriaList {SetCriteria = "Gateway"} 
            };
            this.OperatorList = new ObservableCollection<SearchOperatorLists>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<SearchCriteriaList> CriteriaList { get; private set; }
        
        public SearchCriteriaList SelectedCriteriaList 
        {
            get { return this.selectedCriteriaList; }
            set
            {
                if (value != this.selectedCriteriaList)
                {
                    this.selectedCriteriaList = value;
                    this.OnPropertyChanged("SelectedCriteriaList");
                    this.UpdateOperators();
                }
            }
        }
        public ObservableCollection<SearchOperatorLists> OperatorList { get; private set; }
        private void UpdateOperators()
        {
            this.OperatorList.Clear();
            if (this.SelectedCriteriaList == this.CriteriaList[0])
            {
                foreach (SearchOperatorLists item in this.dateOperatorList)
                {
                    this.OperatorList.Add(item);
                }
            }
            else if (this.SelectedCriteriaList == this.CriteriaList[1])
            {
                foreach (SearchOperatorLists item in this.gatewayOperatorList)
                {
                    this.OperatorList.Add(item);
                }
            }
        }
        private void OnPropertyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
