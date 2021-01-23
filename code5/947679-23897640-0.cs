    public class SearchCriteria
    {
       public int PatientId {get;set;}
       public int HospitalId
    }
    
    public class PoliceSearchCriteria : SearchCriteria
    {
       public string FirstName {get;set;}
       public string LastName {get;set;}
