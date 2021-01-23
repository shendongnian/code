    public enum ContentType
    {
        Question,
        Answer
    }
    public abstract class ContentBase
    {
        public int Id { get; set; }
    
        public string Title { get; set; }
    
        public string Author { get; set; }
    
        public abstract ContentType Type { get; }
    }
    public class Question : ContentBase
    {
        public override ContentType Type
        {
            get { return ContentType.Question; }
        }
    }
    
    public class Answer: ContentBase
    {
        public override ContentType Type
        {
            get { return ContentType.Answer; }
        }
    }
