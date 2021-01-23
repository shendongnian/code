    public class VacationItemViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public string Header { get; set; }
        private string _name;
        private string _value;
        [DataMember]
        public string Name
        {
            get { return _name; }
            set { this.SetProperty(ref _name, value); }
        }
        [DataMember]
        public string Value
        {
            get { return _value; }
            set { this.SetProperty(ref _value, value); }
        }
        private ObservableCollection<VacationItemViewModel> vacationItemViewModelItems = new ObservableCollection<VacationItemViewModel>();
        public ObservableCollection<VacationItemViewModel> VacationItemViewModelItems
        {
            get { return vacationItemViewModelItems; }
            set { vacationItemViewModelItems = value; }
        }
        // ...
    }
