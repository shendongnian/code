    using Newtonsoft.Json;
    ...
    public class SomeTable: INotifyPropertyChanged
    {
        private Int64 _id;
        [JsonProperty(PropertyName = "id")]
        public Int64 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("id");
                }
            }
        }
        private string _name;
        [JsonProperty(PropertyName = "name")]
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name= value;
                    NotifyPropertyChanged("_name");
                }
            }
        }
