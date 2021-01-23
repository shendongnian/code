    public class UserViewModel
    {
        public UserViewModel()
        {
            EditCommand = new RelayCommand(EditSelectedUser, () => SelectedUser != null);
        }
    
        private void EditSelectedUser()
        {
            // some edit code here
        }
    
        public User SelectedUser { get; set; }
        public ICommand EditCommand { get; private set; }
    }
