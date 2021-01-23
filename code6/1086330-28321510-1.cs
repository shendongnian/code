    public class UserVM
    {
        public string Login { get; set; }
        public string Pwd { get; set; }
        public ObservableCollection<UserVM> Users { get; private set; }
        public UserVM(User user)
        {
            Login = user.Login;
            Pwd = user.Pwd;
            Users = new ObservableCollection<UserViewModel>(
                user.GetUsers().Select(subUser => new UserViewModel(subUser)));
        }
    }
