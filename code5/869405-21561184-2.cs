    public class Item
    {
        [JsonConverter(typeof(CrazyStringConverter))]
        public string Name { get; set; }
        public Guid? Id { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> CustomFields
        {
            get
            {
                if (_customFields == null)
                    _customFields = new Dictionary<string, object>();
                return _customFields;
            }
            private set
            {
                _customFields = value;
            }
        }
        private Dictionary<string, object> _customFields;
    }
