    public class Item : INotifyPropertyChanged
    {
      // Omitted implementation of INPC
      private string _name;
      public string Name { get { return name; } set { _name = value; RaisePropertyChanged(); } }
      
      public void Update()
      {
         Name = "NewValue"; // This will show up in the UI if it is bound to a property (DataBinding)
      }
    }
