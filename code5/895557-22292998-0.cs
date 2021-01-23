    public class TestQuestionAnswerModel
    {
        public int AnswerUId { get; set; }
        public bool? Correct { get; set; }
        public bool? Response { get; set; }
        public string Text { get; set; }
        public string Serialize()
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(this);
        }
        public static TestQuestionAnswerModel Create(string data)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return (TestQuestionAnswerModel)serializer.Deserialize<TestQuestionAnswerModel>(data);
        }
    }
