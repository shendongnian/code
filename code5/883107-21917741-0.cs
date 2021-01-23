    public class QuestionMainModel
    {
        public List<QuestionViewModel> Questions { get; set; }
    }
    public class QuestionViewModel
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public List<QuestionOptionViewModel> Options { get; set; }
        public int Selected { get; set; }
    }
    public class QuestionOptionViewModel
    {
        public int? Id { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }        
    }
