      ICommand _addCommand;
      public ICommand AddCommand
      {
          get
          {
             if (_addCommand == null)
             {
                 _addCommand = new RelayCommand(param => AddItem((Product) param));
             }
             return _addCommand;
         }
     }
     private void AddItem(Product newItem)
     {
         m_Products.Add(newItem);  
     }
