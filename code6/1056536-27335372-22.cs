    [DataContract]
    public class MyContainer
    {
        public MyContainer() {
            this.Dictionary = new Dictionary<MyValue, int>();
        }
        [DataMember]
        public MyValue MyValue { get; set; }
        [IgnoreDataMember]
        public Dictionary<MyValue, int> Dictionary { get; set; }
        [DataMember(Name="Dictionary")]
        private KeyValuePair<MyValue, int> [] SerializedDictionary
        {
            get
            {
                if (Dictionary == null)
                    return null;
                return Dictionary.ToArray();
            }
            set
            {
                if (value == null)
                {
                    Dictionary = null;
                }
                else
                {
                    Dictionary = value.ToDictionary(pair => pair.Key, pair => pair.Value);
                }
            }
        }
    }
