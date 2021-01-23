    public class Question
    {
        public Question() { this.Answers = new List<Answer>(); }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
    public static class TextExtension
    {
        public static string CleanQuestion(this Question @this)
        {
            if (@this.Text == null) { return null; }
            else
            {
                return (Regex.Replace(@this.Text, "<p>&nbsp;</p>$", ""));
            }
        } 
    }
        // Usage:
        Question q1= new Question();
        q1.CleanQuestion();
