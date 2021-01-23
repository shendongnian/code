    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            SelectedItemChangedCommand = new DelegateCommand<object>((selectedItem) => 
            {
                var selected = selectedItem as Company;
                SelectedCompanyPhoneNumbers = selected.CompanyPhoneNumbers;
            });
        }
        public view LoadCompanies()
        {
            // Load the companies information from different tables ...
        }
        public List<Company> Companies { get; set; }
        public DelegateCommand<object> SelectedItemChangedCommand { get; set; }
        public List<string> SelectedCompanyPhoneNumbers { get; set; }
    }
