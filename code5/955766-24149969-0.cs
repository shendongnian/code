    public class Parameter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParameterId { get; set; }
        ...
        [ForeignKey("AnalysisId")]
        public Analysis Analysis { get; set; }
        public int AnalysisId { get; set; }
    }
    
    public class Analysis
    {
        ...
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalysisId { get; set; }
        
        virtual public ICollection<Parameter> Parameters { get; set; }
    }
