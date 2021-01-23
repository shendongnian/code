    public class ShellViewModel : Conductor<object> {
        public ShellViewModel() {
            ShowLogin();
        }
        public LoginViewModel { get; set; }
        public MasterViewModel { get; set; }
        public void ShowLogin() {
            ActiveItem = LoginViewModel;
        }
        public void ShowMaster() {
            ActiveItem = MasterViewModel;
        }
    }
