    public class SampleDetailValues // this is the detail entity
    {
       public int Id { get; set; }
    }
    // typically done with a join table, since arrays cant be modelled to scalar DB types
    public class SampleParameterIds
    {
        public int Id { get; set; }
        public string SampleParameterName {get;set}
        public int DetailId { get; set; } 
        [ForeignKey("DetailId")]
        public virtual SampleDetailValues detailValue {get; Set;}          
        [ForeignKey("SampleParamaterName")]
        public virtual SampleParamter sampleParameter {get; Set;}          
    }
    public class SampleParameter // this is a class that i will use for the business logic
    {
        public string Name { get; set; }
    //   public SampleDetailValues[] SampleDetail { get; set; } // see join table 
        public double { get; set; }
    }
