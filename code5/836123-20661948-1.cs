    public PartDTO : DictionaryAsDTO<Part>
    {
        public PartDTO(Part p, string listOfProperties) : base(p, listOfProperties) {}
       
        // Override method to populate base's dictionary with Part properties based on
        // listOfProperties
    }
