    public class JobHistory
    {
     public string CompName, Tech, Profile;
     public string StartDate;
     public string EndtDate;
     public int CurrentAnnualSalary;
     public JobHistory(string CompName, string Tech, string Profile, 
                           string StartDate, string EndtDate, 
                           int CurrentAnnualSalary)
        {
            this.CompName = CompName;
            this.Tech = Tech;
            this.Profile = Profile;
            this.StartDate = StartDate;
            this.EndtDate = EndtDate;
            this.CurrentAnnualSalary = CurrentAnnualSalary;
        }
      
     //If required then you can also need write out the empty constructor 
        public JobHistory(){}     
  
    }
