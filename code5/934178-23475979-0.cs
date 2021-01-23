     public class YourViewModel
     {
         public ObservableCollection<YourDataType> YourCollection { get; set; } 
         public ICommand ReloadDataCommand { get; set; }
         public YourViewModel()
         {
             YourCollection = new ObservableCollection<YourDataType>();
             ReloadDataCommand = new DelegateCommand(ReloadData);
         }
         private void ReloadData()
         {
             //Get your new data;
             YourCollection = new ObservableCollection(someService.GetData());
             RaisePropertyChange("YourCollection");
             //Depending on how many items your bringing in will depend on whether its a good idea to recreate the whole collection like this. If its too big then you may be better off removing/adding these items as needed.
         }
     }
