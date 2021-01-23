    [DataContract]
    public class ObjectList
    {
        [DataMember]
        public ObservableCollection<string> ObjectListInstance = new ObservableCollection<string>();
        [DataMember]
        public string Name;
    }
