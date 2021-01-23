    public class MatrixModel
    {
        public class Option
        {
            public string text { get; set; }
            public string selectedMarks { get; set; }
        }
        public class Model
        {
            public List<Option> options { get; set; }
            public int maxOptions { get; set; }
            public int minOptions { get; set; }
            public bool isAnswerRequired { get; set; }
            public string selectedOption { get; set; }
            public string answerText { get; set; }
            public bool isRangeType { get; set; }
            public string from { get; set; }
            public string to { get; set; }
            public string mins { get; set; }
            public string secs { get; set; }
        }
        public class Question
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
            public int TypeId { get; set; }
            public string TypeName { get; set; }
            public Model Model { get; set; }
        }
        public class RootObject
        {
            public Question Question { get; set; }
            public string CheckType { get; set; }
            public string S1 { get; set; }
            public string S2 { get; set; }
            public string S3 { get; set; }
            public string S4 { get; set; }
            public string S5 { get; set; }
            public string S6 { get; set; }
            public string S7 { get; set; }
            public string S8 { get; set; }
            public string S9 { get; set; }
            public string S10 { get; set; }
            public string ScoreIfNoMatch { get; set; }
        }
    }
