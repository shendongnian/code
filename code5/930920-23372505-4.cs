    [Serializable]
    class parameter
    {
         [Datamember]
         public string name {get; set;}
         [Datamember]
         public string label {get; set;}
         [Datamember]
         public string unit {get; set;}
         [Datamember]
         public component thisComponent {get; set;}
    }
    [Serializable]
    class component
    {
        [Datamember]
        public string type {get; set;}
        [Datamember]
        public List<attribute> attributes  {get; set;}
    }
    [Serializable]
    class attribute
    {
        [Datamember]
        public string? type {get; set;}
        [Datamember]
        public string? displayed {get; set;}
        [Datamember]
        public string? add_remove {get; set;}
        [Datamember]
        public string? ccypair {get; set;}
        [Datamember]
        public List<int> item { get; set;}
    }
