    public class UserQuiz {
      public Int32 Id { get; set; }
      public Int32 Note { get; set; }
      public Int32? Factor { get; set; }
      public Evaluation Evaluation { get; set; }
    }
    List<UserQuiz> examsAndTest=new List<UserQuiz>();
    examsAndTest.AddRange(userExams.Select(e=>new UserQuiz(){ Id= e.Id /* copy the other properties here */}).ToList());
    examsAndTest.AddRange(userTests.Select(e=>new UserQuiz(){ Id= e.Id /* copy the other properties here */}).ToList());
    UserQuiz latestRecord=  examsAndTest.OrderByDescending(e=>e.Evaluation.Created).FirstOrDefault();
