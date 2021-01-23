    public class UserViewModel
    {
        public UserViewModel()
        {
            CustomerViewModel = new CustomerViewModel();
        }
    
        public CustomerViewModel CustomerViewModel { get; set; }
    }
