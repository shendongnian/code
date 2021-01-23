    public class ResultDTO
    {
        public int Id { get; private set; }
        public string Text { get; set; }
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public ResultDTO(int id, string _text, int ansId, string ansText)
        {
            Id=id;
            Text = _text;
            AnswerId = ansId;
            AnswerText = ansText;
        }
    }
