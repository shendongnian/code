    public interface IModel
    {
        string Text { get; set; }
    }
    
    public class MyQuestionModel : IModel
    {
        public MyTitleModel Title { get; set; }
        public string Field1 { get; set; }
        public string Text { get; set; }
    }
    
    public class MyTitleModel : IModel
    {
        public string Field2 { get; set; }
        public string Text { get; set; }
    }
