    public class JobHistory
    {
     public string CompName{get;set}
     public string Tech {get;set;}
     public string Profile{get;set;}
     //More properties ....
     public JobHistory()
     {}
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
       
    }
