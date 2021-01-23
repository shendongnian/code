    public class UserEditForm : Form {
    
        private reaodnly UserEditViewModel viewModel;
    
        public UserEditForm(UserEditViewModel viewModel) {
            this.viewModel= viewModel;
        }
        
        public void Load(int userId) {
            this.viewModel.Load(userId);
        }
        
        ...
    }
    
    public class UserEditViewModel {
    
        private readonly UserRepository repository;
    
        public UserEditViewModel(UserRepository repository) {
            this.repository = repository;
        }
    
        ...
    }
