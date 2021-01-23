    public class ComparisonData
    {
        public List<string> Tables { get; set; }
        public List<string> Constraints { get; set; }
        public List<string> StoredProcs { get; set; }
        public List<string> Views { get; set; }
        public List<string> Functions { get; set; }
        public List<string> Columns { get; set; }
        public List<string> Synonyms { get; set; }
        public List<string> NotNullables { get; set; }
    
        public ComparisonData()
        {
            Tables = new List<string>();
            Constraints = new List<string>();
            // other properties...
        }
    }
