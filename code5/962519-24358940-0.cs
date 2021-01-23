        public class HintQuestion
        {
            public string QuestionCode { get; set; }
            public string QuestionName { get; set; }
        }
        public class User
        {
            public User()
            {
                this.HintQuestion = new HintQuestion();
            }
            public HintQuestion HintQuestion { get; set; }
        }
    User u = new User { HintQuestion = new HintQuestion { QuestionCode = "test", QuestionName = "test1" } };
                
