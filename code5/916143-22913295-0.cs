     public class ItemsMenu : IBaseItem
     {
         public ItemsMenu()
         {
              SubItems = new ObservableCollection<IBaseItem>();
         }
         public ObservableCollection<IBaseItem> SubItems { get; set; }
         public string Name { get; set; }
     }
