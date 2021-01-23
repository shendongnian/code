    public class MVVMTabControlViewModel: PropertyChangedBase
    {
        public ObservableCollection<MVVMTabItemViewModel> Tabs { get; set; }
        private MVVMTabItemViewModel _selectedTab;
        public MVVMTabItemViewModel SelectedTab
        {
            get { return _selectedTab; }
            set
            {
                _selectedTab = value;
                OnPropertyChanged("SelectedTab");
            }
        }
        public Command AddNewTabCommand { get; set; }
        public MVVMTabControlViewModel()
        {
            Tabs = new ObservableCollection<MVVMTabItemViewModel>();
            AddNewTabCommand = new Command(AddNewTab);
        }
        private void AddNewTab()
        {
            //Here I just create a new instance of TabViewModel
            //If you want to copy the **Data** from a previous tab or something you need to 
            //copy the property values from the previously selected ViewModel or whatever.
            
            var newtab = new Tab1ViewModel {Title = "Tab #" + (Tabs.Count + 1)};
            Tabs.Add(newtab);
            SelectedTab = newtab;
        }
    }
