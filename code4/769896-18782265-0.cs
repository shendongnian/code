    public class SinglePest
    {
        public int SinglePestId { get; set; }
        public IEnumerable<PestType> Pests { get; set; }
        public PestType PestType { get; set; }
        public string Alias { get; set; }
        public string  TechName { get; set; }
        public string Markings { get; set; }
    
        public string SerialNumber { get; set; }
        public SourceType SourceType { get; set; }
    
        //virtual property
        public Source Source { get; set; }
    }
