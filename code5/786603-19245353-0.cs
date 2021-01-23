    namespace TestDashBoard.ViewModels
    {
        public class MenuItemViewModel : ViewModelBase
        {
            public RelayCommand _salesSetupClicked;
            public RelayCommand SalesSetupClicked
            {
                get
                {
                   if (_salesSetupClicked == null)
                      _salesSetupClicked = new RelayCommand(ShowSalesSetup);
                   return _salesSetupClicked;
                };
                private set;
            }
            public RelayCommand InvtSetupClicked 
            { 
                get; 
                private set; 
            }
    
            public MenuItemViewModel()
            {
                SalesSetupClicked = new RelayCommand(() => 
                {
                    ShowSalesSetup();
                });
    
                InvtSetupClicked = new RelayCommand(() =>
                {
                    ShowInvtSetup();
                });
            }
    
            private void ShowSalesSetup()
            {
            }
            private void ShowInvtSetup()
            {
            }
        }
    }
