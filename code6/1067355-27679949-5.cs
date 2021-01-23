      ICommand _addCommand;
      public ICommand AddCommand
      {
          get
          {
             if (_addCommand == null)
             {
                 _addCommand = new RelayCommand(param => AddItem());
             }
             return _addCommand;
         }
     }
     private void AddItem()
     {
         m_Products.Add(new Product(ID,Name,Price));  
     }
