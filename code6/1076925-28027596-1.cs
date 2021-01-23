    public ICommand CustomerSearch
            {
                get
                {
                    CustomerSearch f = new CustomerSearch() { UniqueTabName = "NewTab1", Title = "Customer Search" };
                    CustomerSearchViewModel.AddNewCustomerTab += AddItem;
                    return new DelegateCommand(delegate { this.AddItem(f); });
                }
            }
