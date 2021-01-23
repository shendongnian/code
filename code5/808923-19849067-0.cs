        public class Quiz
        {
            public string Question { get; set; }
            public string Answer { get; set; }
            private bool isAnswered = false;
            public bool IsAnswered
            {
                get { return isAnswered; }
                set { isAnswered = value; }
            }
    
            public Quiz(string question,string answer)
            {
                Question = question;
                Answer = answer;
            }
        }
