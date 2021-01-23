    public class UserRequest : BaseViewModel  {
        public String Text { get; set; }
        public ICommand Command { get; set; }
        public UserRequest()
        {
            Command = new RelayCommand(ActionToExecute);
        }
        public void ActionToExecute()
        {
            //Doing stuff here!
        }
    }
    public class SomeViewModel : BaseViewModel
    {
        public ObservableCollection<UserRequest> UserRequests { get; set; }  
        public SomeViewModel()
        {
            UserRequests = new ObservableCollection<UserRequest>();
            UserRequests.Add(new UserRequest() {Text = "Test1"});
            UserRequests.Add(new UserRequest() { Text = "Test2" });
        }
    }
