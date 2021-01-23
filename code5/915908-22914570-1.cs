    public class AppViewModel
    {
       public ObservableCollection<ButtonViewModel> MyButtons {get; set; }
    
       public AppViewModel()
       {
          MyButtons = new ObservableCollection<ButtonViewModel>();
    
          // add some demo data
          MyButtons.Add(new ButtonViewModel() {ButtonContent = "Click Me!"});
    
    
       }
    }
