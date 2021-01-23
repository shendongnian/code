        public ICommand Edit { get; private set; }
    
     Edit = new RelayCommand(EditUser, x => _isAdmin);
  
     private static void EditUser(object usr)
        {
            if (!(usr is User))
                return;
    
            new UserEditorViewModel(usr as User);
        }
