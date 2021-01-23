    public class Question
    {
        public int Id {get; set;}
        public string Text {get; set;}
        public Answer[] Answers {get; set;}
    }
    public class QuestionSelector
    {
        private readonly List<int> _previousQuestionIds = new List<int>();
        public Question NextQuestion()
        {
            var query = "select top 1 * from Questions ";
            if(ids.Any())
            {
                var ids = String.Join(",", _previousQuestionIds.Select(id=>id.ToString()));
                query += "  where id not in (" + ids + ") ";
            }
            query += " order by rand()";
            var question = ParseQuestion(query);
            _previousQuestionIds.Add(question.Id);
            return question;
        }
        private Question ParseQuestion(string query)
        {
            // query the database and convert the data from the returned row
        }
    }
