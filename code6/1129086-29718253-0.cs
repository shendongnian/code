    public class UserSalutationViewModel : Screen
    {
        private readonly string _userName;
        private readonly IDataService _dataService;
        private string _selectedSalutation;
        public UserSalutationViewModel(string userName, IDataService dataService)
        {   
            _userName = userName;
            _dataService = dataService;
            Salutions = new BindableCollection<string>(_dataService.GetAvailableSalutations());
            _selectedSalutation = _dataService.GetUserSalutation(_userName);
        }
        // List with selectable salutations. Bound in the View to a ListBox element.
        public BindableCollection<string> Salutions { get; private set;}
        // Caliburn Micro will automatically bind this to the selected item in the ListBox.
        public string SelectedSalutation 
        {
            get { return _selectedSalutation; }
            set
            {
                _selectedSaluation = value;
                NotifyOfPropertyChange(() => SelectedSalutation);
                // Notify the view to refresh with the new user salutation value
                NotifyOfPropertyChange(() => UserSaluation);
            }
        }
        // This returns a model constructed value. Bound to a Label element in the View
        public string UserSalutation
        {
            get { return _selectedSaluation + " " + _userName; }
        }
        // Saves the selected salutation. Bound to a Button in the View
        public void Save()
        {
            _dataService.SaveUserSalutation(_userName, _selectedSalutation);
        }
    }
