    public class RowData: INotifyPropertyChanged
    {
        //implement INotifyPropertyChanged
        public string Type { get; set; }
        public string MapTo { get; set; }
        public string Name { get; set; }
        public bool Controller { get; set; }
        public bool Service { get; set; }
        public bool Injection { get; set; }
    }
