        public class ResultDTO
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public int AnswerId { get; set; }
            public string AnswerText { get; set; }
        }
    
    List<ResultDTO> result1 = new List<ResultDTO> () {
       new ResultDTO () { Id=1, Text= "abc", AnswerId= "1", AnswerText= "Aab1" },
       new ResultDTO () { Id=1, Text= "abc", AnswerId= "2", AnswerText= "Aab2" },
       new ResultDTO () { Id=1, Text= "abc", AnswerId= "3", AnswerText= "Aab3" },
       new ResultDTO () { Id=1, Text= "def", AnswerId= "4", AnswerText= "Aab4" },
       new ResultDTO () { Id=1, Text= "def", AnswerId= "5", AnswerText= "Aab5" },
       new ResultDTO () { Id=1, Text= "def", AnswerId= "6", AnswerText= "Aab6" }
    }
