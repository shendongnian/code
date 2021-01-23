     public static class DeleteEmployerTimer
    {
        static private JobsEntities JobDatabase=new JobsEntities();
        private static Timer threadingTimer;
      
         public static void StartTimer()
         {
             if (threadingTimer==null)
             {
                 //raise timer callback every 5 minutes
                 threadingTimer = new Timer(new TimerCallback(CheckData),
                                           HttpContext.Current, 5 * 60000, 5 * 60000);
             }
        }
        private static void CheckData(object sender)
        {
            MembershipUserCollection AllEmployer = Membership.GetAllUsers();
            foreach (MembershipUser Employer in AllEmployer)
            {
                //your condition to delete records (it can be everything you want date, specific data in config file)
                if(!Employer.IsApproved)
                {
                    MeWork.Domain.Database.Employer FindedEmployer = JobDatabase.Employer.Find(Employer.ProviderUserKey);
                    JobDatabase.Employer.Remove(FindedEmployer);
                    JobDatabase.SaveChanges();
                    Membership.DeleteUser(Employer.UserName, true);
                }
            }
        }
    }
