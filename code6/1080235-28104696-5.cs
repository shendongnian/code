      public class Candidate
      {
        int CandidateId;
        JobHistory jh1 = new JobHistory();
        PersonalInformation pi = new PersonalInformation();
        
        List<Skill> CandidateSkills = new List<Skills>();        
        public Candidate(int CandidateId,JobHistory jh2,PersonalInformation pi2)
        {
            this.CandidateId = CandidateId;
            this.jh1= new JobHistory (jh2.CompName, jh2.Tech, jh2.Profile, 
                            jh2.StartDate, jh2.EndtDate, 
                            jh2.CurrentAnnualSalary);
            this.pi =  new PersonalInformation (pi2.FirstName, pi2.LastName, pi2.DateOfBirth,
                           pi2.PhoneNo1, pi2.PhoneNo2, 
                           pi2.TotalExperienceInMonths, pi2.EmailId);
        }
        public void UpdateExisting();
        public void Delete();
    }
