    public class DataControl {
        public string Type { get; set; }
        public INotifyCollectionChanged Data;
    
        public DataControl(string type, INotifyCollectionChanged data) {
            Type = type;
            Data = data;
        }
    }
