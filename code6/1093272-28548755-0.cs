    public class ApplicantInformationModel
    {
        public string Name {get; set;}
        public string Email {get; set;}
        public List<Job> Jobs {get; set;}
        public string PhoneNumber {get; set;}
    }
    
    public class Job
    {
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public string Title {get; set;}
        public string Company {get; set;}
    }
