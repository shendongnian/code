    public class UserScreenViewModel : ViewModelBase
    {
       public void SetSelectedTabItem()
       {
          this.SelectedTabItem = this.Items[0];
       }
    }
    
    public class NewClass
    {
       public UserScreenViewModel UserViewModel {get; set;}
    
       public NewClass(UserScreenViewModel userViewModel)
       {
           this.UserViewModel = userViewModel;
           this.UserViewModel.SetSelectedTabItem();
       }
    }
