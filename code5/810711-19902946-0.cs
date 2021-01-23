    public class UserScreenViewModel : ViewModelBase
    {
       public void SetSelectedItem()
       {
          this.SelectedTabItem = this.Items[0];
       }
    }
    
    public class NewClass
    {
       public UserScreenViewModel UserViewModel {get; set;}
    
       public NewClass()
       {
           this.UserViewModel = new UserViewModel();
           this.UserViewModel.SetSelectedItem();
       }
    }
