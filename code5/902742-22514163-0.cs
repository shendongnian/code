    public class GroceryItemVm : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string ProductInfoLabel{ get; set; }
    
        public ICommand EditGroceryItemCmd { get; private set; }
        public ICommand DeleteGroceryItemCmd { get; private set; }
    }
