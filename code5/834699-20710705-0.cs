    public class OwnerDef : INotifyPropertyChanged   // raise property changed on each
    {
        public OwnerType OwnerType { get; set; }  
    }
    public class OwnerTypeDef : INotifyPropertyChanged   // raise property changed on each
    {
        public string Name { get; set; }  
    }
    public class ViewModel : INotifyPropertyChanged   // raise property changed on each
    {
        public List<OwnerTypeDef> OwnerTypes { get; set; }
        public OwnerDef Owner { get; set; }
    }
