    public class CustomerDetailsViewModel : BaseViewModel
    {
        private string _detailPageSource;
        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set { Set(() => SelectedMenuItem, ref _selectedMenuItem, value); }
        }
        public RelayCommand<MenuItem> MenuItemSelectedCommand { get; private set; }
        public ObservableCollection<IMenuItem> Details { get; set; }
        public CustomerDetailsViewModel()
        {
            
           Details = new ObservableCollection<IMenuItem>()
            {
                 new MenuItem()
                {   
                    DestinationPage = typeof (Demographics),
                    Name = "Demographics"
                },
                new MenuItem()
                {
                    DestinationPage = typeof(OrderProductList),
                    Name = "Order Product List"
                }
            };
            SelectedMenuItem = Details.Single(m => m.Name == "Demographics") as MenuItem;
        }
        public override void ClearViewModel()
        {
            throw new NotImplementedException();
        }
    }
