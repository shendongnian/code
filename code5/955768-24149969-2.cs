    public class Parameter
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParameterId { get; set; }
        ...
        virtual public ICollection<Analysis> Analyses { get; set; }
    }
    
    public class Analysis
    {
        ...
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnalysisId { get; set; }
        
        virtual public ICollection<Parameter> Parameters { get; set; }
    }
