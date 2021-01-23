    public class SearchCriteria
    {
       public SearchCriteria(int patientId, int hospitalId)
       {
           PatientId = patientId;
           HospitalId = hospitalId;
       }
       public int PatientId {get;set;}
       public int HospitalId {get;set;}
    }
    
    public class PoliceSearchCriteria : SearchCriteria
    {
       public PoliceSearchCriteria(int patientId, int hospitalId, string first, string last) 
       : base(patientId, hospitalId)
       {
           FirstName = first;
           LastName = last;
       }
       public string FirstName {get;set;}
       public string LastName {get;set;}
    }
