    public class ViewModel
    {
       public ViewModel()
       {
          CustomItems = new ObservableCollection<CustomClass>();
          CustomItems.Add(new CustomClass() { "All" });
          CustomItems.Add(new CustomClass() { "General" });
       }
       
       private ObservableCollection<CustomClass> customItems = null;
       public ObservableCollection<CustomClass> CustomItems
       {
          get { return customItems; }
          set
          {
             if (object.Equals(value, customItems) == false)
             {
                customItems = value;
                OnPropertyChanged(() => CustomItems);
             }
          }
       }
       
       private CustomClass selectedCustomItem = null;
       public CustomClass SelectedCustomItem
       {
          get { return selectedCustomItem; }
          set
          {
             if (object.Equals(value, selectedCustomItem) == false)
             {
                selectedCustomItem= value;
                OnPropertyChanged(() => SelectedCustomItem);
             }
          }
       }
    }
