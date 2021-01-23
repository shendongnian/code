       private RelayCommand<FoodItem> _addToGroceriesCommand;
       public ICommand AddToGroceriesCommand
       {
            get
            {
                if (_addToGroceriesCommand == null)
                {
                    _addToGroceriesCommand = new RelayCommand<FoodItem>(OnAddToGroceries);                    
                }
                return _addToGroceriesCommand;
            }
        }
       public void OnAddToGroceries(FoodItem newItem)
       {
       
       }
