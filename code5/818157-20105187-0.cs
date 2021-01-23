    enum PersonType
    {
        American, Asian, European
    }
    
    interface IPerson
    {
        string Name { get; set; }
        PersonType Type { get; }
    }
    American : IPerson
    {
        public string Name { get; set; }
        public PersonType Type { get { return PersonType.American; } }
    }
