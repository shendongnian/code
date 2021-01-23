    public class PropertyGridRow : INotifyPropertyChanged
    {
        public string PropertyName { get; set; }
        public object PropertyValueBefore { get; set; }
        public object PropertyValueAfter { get; set; }
    }
