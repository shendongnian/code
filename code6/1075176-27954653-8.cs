        [IgnoreDataMember]
        [XmlIgnore]
        [ScriptIgnore]
        public ObservableCollection<String> { get; set; } // Or List<string> or etc.
        [XmlArray("Associates")]
        [DataMember(Name="Associates")]
        public string[] AssociateArray
        {
            get
            {
                return (Associates == null ? null : Associates.ToArray());
            }
            set
            {
                if (Associates == null)
                    Associates = new ObservableCollection<string>();
                Associates.Clear();
                if (value != null)
                    foreach (var item in value)
                        Associates.Add(item);
            }
        }
