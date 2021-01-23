    public class Cars
    {
        public int CarID {get;set}
        public int CarName {get;set}
        // Foreign key
        public int EngineMakerID { get; set; }
     
        // Navigation properties
        public virtual EngineMakers  EngineMakers  { get; set; }
    }
    public class EngineMakers
    {
        public int EngineMakerID {get;set}
        public int EngineMakerName {get;set}
        // Navigation properties
        public virtual List<EngineMakers> Courses { get; set; }
    }
