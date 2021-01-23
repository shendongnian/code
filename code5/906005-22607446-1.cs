     public FilterViewModel()
        {
         private RelayCommand _commandSave;
         public ICommand Save
          {
            get { 
               return _commandSave ?? (_commandSave = 
               new RelayCommand(param => SaveMethod(param), CanSave)); 
               }
           }
      private void SaveMethod 
        {
         //code for save
        }
       private Predicate<object> CanSave
        {
            get { return o => true; }
        }
      }
