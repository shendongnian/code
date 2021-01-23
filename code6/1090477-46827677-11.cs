    public class PageHomeVM : PropertyValidation
    {
       private ICommand saveCommand;
       public ICommand SaveCommand {
          get {
             return saveCommand;
          }
          set {
             saveCommand = value;
             OnPropertyChanged();
          }
       }
    
       public MyModel MyModel { get; set; } = new MyModel();
    
       public PageHomeVM()
       {
          SaveCommand = new RelayCommand(SaveRecord, p => MyModel.IsValid);
          MyModel.ClearValidation();
       }
    
       public void SaveRecord(object p)
       {
          //Perform the save....
       }
    }
