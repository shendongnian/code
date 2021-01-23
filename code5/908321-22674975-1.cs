    IEnumerable<Contracts.User> GetAllUsers()
    {
       foreach (DB.User in context.Users)
       {
           Contracts.User wcfUser = new Contracts.User();
           wcfUser.Exams = new List<Contracts.Exam>();
           foreach (DB.Exam exam in wcfUser.Exams)
              wcfUser.Exams.Add(new Contracts.Exam() { Score = exam.Score };
    
           yield return wcfUser;
       }
    }
