    public class ElementViewModel : INotifyPropertyChanged
    {
        public int Depth {get;set;}
        public IEnumerable<ElementViewModel> Elements {get; set;}
        
        ...
    }
