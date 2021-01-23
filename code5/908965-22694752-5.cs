    public class ViewModel
    {
        public ObservableCollection<User> Users {get; private set;}
    
        public ViewModel()
        {
            Users = new ObservableCollection<User>();
    
            //... Populate the collection here.
        }
    }
