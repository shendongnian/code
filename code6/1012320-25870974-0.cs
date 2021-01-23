    public class QuestionsResult : IHttpActionResult
    {
        public QuestionResult(IEnumerable<Question> questions>, int? nextPage)
        {
           /// set the properties here
        }
        public IEnumerable<Question> Questions { get; private set; }
        public int? NextPage { get; private set; }
        /// ... execution goes here
    }
