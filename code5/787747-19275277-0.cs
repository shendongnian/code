    public class Concern
    {
        public int ConcernID { get; set; }
        public bool LifeExpectancy { get; set; }
        public bool CollateralHistoryAvailable { get; set; }
    }
    
    public class PatientConcernsViewModel
    {
        public int ConcernID { get; set; }
    
        public bool LifeExpectancy { get; set; }        
        public bool CollateralHistoryAvailable { get; set; }
    
    }
