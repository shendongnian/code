    public enum YesNo
    {
        Yes,
        No
    }
    
    public class Concern
    {
        public int ConcernID { get; set; }
        public YesNo LifeExpectancy { get; set; }
        public YesNo CollateralHistoryAvailable { get; set; }
    }
    
    public class PatientConcernsViewModel
    {
        public int ConcernID { get; set; }
    
        public YesNo LifeExpectancy { get; set; }        
        public YesNo CollateralHistoryAvailable { get; set; }
    
    }
