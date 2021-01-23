    class ContextItem : INotifyPropertyChanged
    {
        public string Name;
        public ICommand Action;
        public Brush Icon;
    }
    ObservableCollection<ContextItem> Items {get;set;}
